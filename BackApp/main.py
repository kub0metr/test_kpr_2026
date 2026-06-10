from fastapi import FastAPI
from models import base_model
from routers import customer, food, order, recipe, sales, products

bakery_app = FastAPI()

# bakery_app.add_api_route(customer.router)
# bakery_app.add_api_route(food.router)
# bakery_app.add_api_route(order.router)
# bakery_app.add_api_route(recipe.router)
# bakery_app.api_route(sales.router)
bakery_app.include_router(products.router)
