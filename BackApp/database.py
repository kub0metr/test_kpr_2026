from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker, DeclarativeBase

DATABASE_URL = "postgresql://postgres:123@db:5432/belle"
engine = create_engine(DATABASE_URL)
SesionLocal = sessionmaker(autocommit=False, autoflush=False, bind=engine)


class Base(DeclarativeBase):
    pass


def get_db():
    db = SesionLocal()
    try:
        yield db
    finally:
        db.close()
