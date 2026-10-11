# ButterflyXp API

## POST /butterflies
Create a new butterfly.

Request:
```json
{ "name": "Flora" }
```
Response: **201 Created**
```json
{ "id": "3f2a…", "name": "Flora", "xp": 0, "level": 1 }
```


## PATCH /butterflies/{id}/xp
Give XP to a butterfly.

Request:
```json
{ "amount": 15 }
```
Response: **200 OK**
```json
{ "id": "3f2a…", "name": "Flora", "xp": 15, "level": 2 }
```
- 400 Bad Request – amount is 0 or negative
- 404 Not Found – butterfly does not exist

## GET /butterflies/{id}
Get the status of a butterfly.

Response: **200 OK**
```json
{ "id": "3f2a…", "name": "Flora", "xp": 15, "level": 2 }
```
- 404 Not Found – butterfly does not exist