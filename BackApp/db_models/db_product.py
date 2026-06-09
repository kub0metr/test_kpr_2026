from database import Base
from datetime import datetime
from sqlalchemy import String, Enum
from sqlalchemy.orm import Mapped, mapped_column
from database import Base
from models.product import ProductCategory


class DBProduct(Base):
    """Класс отображающий таблицу Products"""

    __tablename__ = "Products"
    id: Mapped[int] = mapped_column(primary_key=True)
    name: Mapped[str] = mapped_column(String(100), unique=True, nullable=False)
    category: Mapped[ProductCategory] = mapped_column(
        Enum(ProductCategory, values_callable=lambda x: [e.value for e in x]),
        nullable=False,
    )
    ingredients: Mapped[str] = mapped_column(String(1000), nullable=False)
    price: Mapped[float] = mapped_column()
    cost: Mapped[float] = mapped_column()
    is_seasonable: Mapped[bool] = mapped_column()
    is_selling: Mapped[bool] = mapped_column
    created_at: Mapped[datetime] = mapped_column()
