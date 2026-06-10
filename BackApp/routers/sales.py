from fastapi import APIRouter
from models import sale

router = APIRouter(prefix="/bakery/sales", tags=["sales"])

# @router.get("/get_by_product")
# async def get_product_sales(food : str) -> list[sale.Sales]:
#     return ""

# @router.get("/get_by_customer")
# async def get_by_customer(customer_id : int) -> list[sale.Sales]:
#     return ""
