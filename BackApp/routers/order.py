from fastapi import APIRouter
from models import order

router = APIRouter(
    prefix="/bakery/order/",
    tags=""
)

@router.get("/get/{order_id}")
async def get_order_by_id(order_id : int) -> order.Order:
    return ""

@router.post("/create")
async def create_order(order : order.Order) -> id:
    return ""

@router.patch("/change/{order_id}")
async def patch_order(order : order.Order, order_id : int):
    return ""

@router.patch("/change_status/{order_id}")
async def change_status_order(order_id : int):
    return ""
