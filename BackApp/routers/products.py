from fastapi import APIRouter, Depends
from models.product import Product
from sqlalchemy.orm import Session
from database import get_db
from db_models.db_product import DBProduct
from fastapi import HTTPException

router = APIRouter(prefix="/bakery/v2/products", tags=["products"])


@router.get("/", response_model=list[Product])
async def get_products(db: Session = Depends(get_db)) -> list[Product]:
    res = []
    for p in db.query(DBProduct):
        json_product = await get_json_product_by_db_product(p)
        res.append(json_product)
    return res


@router.get("/{product_id}")
async def get_product_by_id(product_id: int, db: Session = Depends(get_db)):
    db_product = [p for p in db.query(DBProduct) if p.id == product_id]
    if len(db_product) == 0:
        raise HTTPException(status_code=404, detail="Нет продукта с таким id")
    return await get_json_product_by_db_product(db_product[0])


@router.post("/")
async def create_new_product(product: Product, db: Session = Depends(get_db)):
    new_db_product = DBProduct(
        name=product.name,
        category=product.category,
        price=product.price,
        cost=product.cost,
    )
    db.add(new_db_product)
    db.commit()
    db.refresh(new_db_product)
    return await get_json_product_by_db_product(new_db_product)


@router.put("/{product_id}")
async def update_product(
    product: Product, product_id: int, db: Session = Depends(get_db)
):
    db_product = db.query(DBProduct).filter(DBProduct.id == product_id).first()
    if not db_product:
        raise HTTPException(status_code=404, detail="Нет продукта с таким id")

    update_data = product.model_dump(exclude_unset=True)
    for key, value in update_data.items():
        setattr(db_product, key, value)

    db.commit()
    db.refresh(db_product)

    return await get_json_product_by_db_product(db_product)


@router.delete("/{product_id}")
async def delete_product(product_id: int, db: Session = Depends(get_db)):
    db_product = db.query(DBProduct).filter(DBProduct.id == product_id).first()
    if not db_product:
        raise HTTPException(status_code=404, detail="Нет продукта с таким id")

    db.delete(db_product)
    db.commit()


async def get_json_product_by_db_product(db_product: DBProduct):
    json_product = Product(
        id=db_product.id,
        name=db_product.name,
        category=db_product.category,
        list_ingredients="",
        price=db_product.price,
        cost=db_product.cost,
        is_seasonable=db_product.is_seasonable,
        is_selling=db_product.is_selling,
        first_date=db_product.created_at,
    )
    return json_product
