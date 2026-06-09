from fastapi import APIRouter
from models import food

router = APIRouter(
    prefix="/bakery/food",
    tags=["food"]
)

@router.get("/get_food_leftovers")
async def get_food_leftovers(food : str) -> float:
    return ""

@router.patch("/change_food_leftovers")
async def change_food_leftovers(food : str, delta : float) -> bool: 
    return ""

@router.put("/create_new_food")
async def create_new_food(food : food.Food) -> bool:
    return ""
