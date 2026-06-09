from pydantic import BaseModel
from models.food import Food

class Recipe(BaseModel):
    food_list : list[Food]
    count_list : list[float]