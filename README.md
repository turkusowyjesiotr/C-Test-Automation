## JSON Placeholder Project

This project aims at automating API request on https://jsonplaceholder.typicode.com/ site.

### Patterns and technologies used:
* RestSharp for requests
* Singleton pattern for API Client class
* Model Classes for data

### Test Case 1
| Steps  | Expected Results |
| ------------- | ------------- |
| 1. Send GET Request to get all posts (/posts)  | Status code is 200<br>The list in response body is JSON<br>Posts are sorted ascending (by id) |

### Test Case 2
| Steps  | Expected Results |
| ------------- | ------------- |
| 1. Send GET request to get post with id=99 (/posts/99)  | Status code is 200<br>Post information is correct: userId is 10, id is 99, title and body aren't empty. |

### Test Case 3
| Steps  | Expected Results |
| ------------- | ------------- |
| 1. Send GET request to get post with id=150 (/posts/150)  | Status code is 404<br>Response body is empty |

### Test Case 4
| Steps  | Expected Results |
| ------------- | ------------- |
| 1. Send POST request to create post with userId=1 and random body and random title (/posts)  | Status code is 201<br>Post information is correct: title, body, userId match data from request, id is present in response. |

### Test Case 5
| Steps  | Expected Results |
| ------------- | ------------- |
| 1. Send GET request to get users (/users)  | Status code is 200<br>The list in response body is JSON<br>User (id=5) data equals to JSON below: |
```json
{
  "id": 5,
  "name": "Chelsey Dietrich",
  "username": "Kamren",
  "email": "Lucio_Hettinger@annie.ca",
  "address": {
    "street": "Skiles Walks",
    "suite": "Suite 351",
    "city": "Roscoeview",
    "zipcode": "33263",
    "geo": {
      "lat": "-31.8129",
      "lng": "62.5342"
    }
  },
  "phone": "(254)954-1289",
  "website": "demarco.info",
  "company": {
    "name": "Keebler LLC",
    "catchPhrase": "User-centric fault-tolerant solution",
    "bs": "revolutionize end-to-end systems"
  }
}
```
### Test Case 6
| Steps  | Expected Results |
| ------------- | ------------- |
| 1. Send GET request to get user with id=5 (/users/5)  | Status code is 200<br>User data matches with user data in the previous step |
