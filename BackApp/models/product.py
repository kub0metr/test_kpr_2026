from pydantic import BaseModel, Field
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

    id: int = 0
    name: str
    category: ProductCategory = ProductCategory.BREAD
    list_ingredients: str | None = None
    price: float
    cost: float
    is_seasonable: bool = False
    is_selling: bool = False
    first_date: datetime = Field(default_factory=lambda: datetime.now())

    class Config:
        from_attributes = True
