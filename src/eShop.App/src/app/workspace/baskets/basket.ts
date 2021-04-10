import { BasketItem } from "./basket-item";

export type Basket = {
    basketId?: string,
    customerId: string,    
    items: BasketItem[]
};
