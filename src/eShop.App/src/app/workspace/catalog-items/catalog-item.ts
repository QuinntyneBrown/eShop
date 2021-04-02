export type CatalogItem = {
    catalogItemId?: string,
    name: string,
    description: string,
    price: number,
    quantityInStock: number,
    onReOrder: boolean,
    catalogItemImages: any[],
    inventoryCount: number
};
