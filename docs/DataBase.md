# Архитектура базы данных

## Таблица Examples

Образцы использования слов на конкретных примерах.
| Field | Type | Decription |
| --- | --- | --- |
| id | primary key |
| word | foreign key to word |
| sentence | string| Пример использования слова |
|translation |string | Перевод |

## Word

Слова, содержащиеся в коллекциях.
| Field | Type | Decription |
| --- | --- | --- |
| id  | primary key | |
|word | string | |
| translation | string | |
| collection | foreign key to collection | |

## Collection

Коллекции слов (карточек).
| Field | Type | Decription |
| --- | --- | --- |
|id | | |
|language of origin | | |
|laguage - 2 | | |
|name | | |
|author | | |
|nickname | | |
