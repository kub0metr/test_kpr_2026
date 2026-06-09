from pydantic import BaseModel

class Food(BaseModel):
    id : int
    name : str
    count : float
    id_recipe : int
    