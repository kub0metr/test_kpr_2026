from pydantic import BaseModel
from datetime import datetime
import enum


class ProductCategory(enum.Enum):
    """
    Энам для отображения категорий продуктов
    """

    VIENNOISERIE = "VIENNOISERIE"
    BREAD = "BREAD"
    PATISSERIE = "PATTISSERIE"
    TARTE = "TARTE"


class Product(BaseModel):
    """Класс для отображения Product в json"""

    id: int
    name: str
    category: ProductCategory
    list_ingredients: str
    price: float
    cost: float
    is_seasonable: bool
    is_selling: bool
    first_date: datetime

    class Config:
        from_attributes = True
