from fastapi import APIRouter
from models import customer

router = APIRouter(
    prefix="/bakery/customer",
    tags=["customer"]
)

@router.get("/get_by_name")
async def get_customers_by_name(name : str) -> list[customer.Customer]:
    return ""

@router.get("get_by_id/{customer_id}")
async def get_customer_by_id(customer_id : int) -> customer.Customer:
    return ""
