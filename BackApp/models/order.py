from pydantic import BaseModel
from datetime import datetime

class Order(BaseModel):
    id : int
    date_order : datetime
    status : str
    customer_id : int