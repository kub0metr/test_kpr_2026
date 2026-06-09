from fastapi import APIRouter, Depends
from models.product import Product
from sqlalchemy.orm import Session
from database import get_db
from db_models.db_product import DBProduct

router = APIRouter(prefix="/v2/products", tags=["products"])


@router.get("/", response_model=list[Product])
async def get_products(db: Session = Depends(get_db)):
    return db.query(DBProduct).all()
