import { CatalogItemImage } from "./catalog-item-image";

export type CatalogItem = {
    catalogItemId?: string,
    name: string,
    description: string,
    price: number,
    quantityInStock: number,
    onReOrder: boolean,
    catalogItemImages: CatalogItemImage[],
    inventoryCount: number
};
