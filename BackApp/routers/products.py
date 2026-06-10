from fastapi import APIRouter, Depends
from models.product import Product
from sqlalchemy.orm import Session
from database import get_db
from db_models.db_product import DBProduct

router = APIRouter(prefix="/bakery/v2/products", tags=["products"])


@router.get("/", response_model=list[Product])
async def get_products(db: Session = Depends(get_db)) -> list[Product]:
    res = []
    for p in db.query(DBProduct):
        json_product = await get_json_product_by_db_product(p)
        res.append(json_product)
    return res


# @router.get("/{id}")
# async def get_product_by_id(db: Session = Depends(get_db)):
#     db_product =
#     return


async def get_json_product_by_db_product(db_product: DBProduct):
    json_product = Product(
        id=db_product.id,
        name=db_product.name,
        category=db_product.category,
        list_ingredients="",
        price=db_product.price,
        cost=db_product.cost,
        is_seasonable=True,
        is_selling=True,
        first_date=db_product.created_at,
    )
    return json_product
