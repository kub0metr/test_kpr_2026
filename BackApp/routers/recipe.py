from fastapi import APIRouter
from models.recipe import Recipe

router = APIRouter(prefix="/bakery/recipe", tags="recipe")

# @router.put("/create_new")
# async def create_new_recipe(recipe : Recipe) -> bool:
#     return ""


# @router.get("/get_by_count")
# async def get_by_count(recipe: Recipe, count: float) -> Recipe:
#     return ""
