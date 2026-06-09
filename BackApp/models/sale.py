from pydantic import BaseModel

class Sale(BaseModel):
    count : int
    dishes : str