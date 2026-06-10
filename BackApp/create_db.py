from typing import List, Optional
from datetime import datetime
from sqlalchemy import create_engine, ForeignKey, String, func, Enum
from sqlalchemy.orm import DeclarativeBase, Mapped, mapped_column, relationship

import enum

DATABASE_URL = "postgresql://postgres:123@db:5432/belle"

engine = create_engine(DATABASE_URL, echo=True)


class ProductCategory(enum.Enum):
    """
    Энам для отображения категорий продуктов
    """

    VIENNOISERIE = "VIENNOISERIE"
    BREAD = "BREAD"
    PATISSERIE = "PATTISSERIE"
    TARTE = "TARTE"


class Gender(enum.Enum):
    MALE = "MALE"
    FEMALE = "FEMALE"


class Status(enum.Enum):
    BASIC = "BASIC"
    SILVER = "SILVER"
    GOLD = "GOLD"


class Base(DeclarativeBase):
    pass


class sales_transactions(Base):
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


class customers(Base):
    """Класс отображающий таблицу Customers"""

    __tablename__ = "Customers"
    customer_id: Mapped[int] = mapped_column(primary_key=True)
    first_name: Mapped[str] = mapped_column(String(100), nullable=False)
    second_name: Mapped[str] = mapped_column(String(100), nullable=False)
    age: Mapped[int] = mapped_column()
    gender: Mapped[Gender] = mapped_column(
        Enum(Gender, values_callable=lambda x: [e.value for e in x]),
        nullable=False,
    )
    postal_code: Mapped[str] = mapped_column(String(6), nullable=False)
    email: Mapped[str] = mapped_column(String(100), nullable=False)
    phone_number: Mapped[str] = mapped_column(String(11), nullable=False)
    membership_status: Mapped[Status] = mapped_column(
        Enum(Gender, values_callable=lambda x: [e.value for e in x]),
        nullable=False,
        default=Status.BASIC,
    )
    join_date: Mapped[datetime] = mapped_column()
    last_purchased_date: Mapped[datetime] = mapped_column()
    total_spending: Mapped[float] = mapped_column()
    average_order_value: Mapped[float] = mapped_column()
    frequency: Mapped[int] = mapped_column()
    preffered_category: Mapped[int] = mapped_column()
    churned: Mapped[bool] = mapped_column(default=False)


def init_db():
    print("Начало создания таблиц")
    Base.metadata.create_all(bind=engine)
    print("Конец создания таблиц")


if __name__ == "__main__":
    init_db()
