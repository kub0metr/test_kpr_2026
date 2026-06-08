from fastapi import FastAPI
from models import base_model

app = FastAPI()

default_text = "корпоративные программные решения"

"""Обработчик стандартного get запроса

    Raises:
        ValueError: Если данные не соотвествуют стандартному формату

    Returns:
        _type_: base_mode.BaseModel
        
    """
@app.get("/get")
async def get(message : base_model.BaseModel):

    if (message["message"] == default_text):
        return default_text
    raise ValueError("Данные введеные неверно")