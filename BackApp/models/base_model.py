from pydantic import BaseModel
'''Модель для стандартного сообщения'''
class StringModel(BaseModel):
    message : str