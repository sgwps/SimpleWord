Example
| Field | Type | Decription |
| --- | --- | --- |
| id | primary key | |
| word | foreign key to word | |
| sentence | string| Пример использования слова |
|translation |string | Перевод |

Word
| Field | Type | Decription |
| --- | --- | --- |
| id  | primary key | |
|word | string | |
| translation | string | |
| collection | foreign key to collection | |


Collection
| Field | Type | Decription |
| --- | --- | --- |
|id | | |
|language of origin | | |
|laguage - 2 | | |
|name | | |
|author | | |
|nickname | | |
