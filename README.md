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

The list in response body is json.

Posts are sorted ascending (by id).  |
| 2. Follow the link "Newsletters" in the header  | Page "Newsletters" is opened  |
| 3. Choose a random newsletter subscription plan |	An email form has appeared at the bottom of the page |
| 4. Enter email, click "Submit" button	| You received an email with a request to confirm subscription |
| 5. Folow the link received from the letter | A page with a message about successful subscription confirmation is opened |
| 6. Click "Back to the site"	| Main page of Euronews is opened |
| 7. Follow the link "Newsletters" in the header, choose the same newsletter subscription plan as in the step 3, click "See preview" | A preview of the required plan is opened |
| 8. On preview find and get a link to unsubscribe from the mailing list, follow this link in the browser	| Unsubscribe page is opened |
| 9. Enter email, click "Submit" button	| A message that the subscription was canceled successfully appears |
| 10. Make sure that you **haven't** received an email with a message about canceling your subscription |	The letter hasn't arrived |
