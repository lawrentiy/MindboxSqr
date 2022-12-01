-- Синтаксис MS SQL

-- Вариант 1
SELECT pr.Name, cat.Name 
FROM products AS pr
LEFT JOIN productsCategories p2c ON p2c.productId = pr.Id
LEFT JOIN  categories AS cat ON p2c.categoryId = cat.Id


-- Вариант 2
SELECT 
    pr.Name, 
    categories=(
        SELECT cat.Name
            FROM productsCategories p2c ON p2c.productId = pr.Id
            INNER JOIN categories AS cat ON p2c.categoryId = cat.Id
    FOR JSON PATH, ROOT('categories'))
FROM products AS pr
