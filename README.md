## Euronews Project

This project aims to mix UI and API automation, prerequisite for this project was to connect test e-mail account on Gmail to Google API (without using frameworks provided by Google, but by pure HTTP requests) and manage one-time manual authorization (opening local browser to give permissions for application and using HTTP Listener class for getting the answer from Google API) and then implement automated token refreshment.

Goal of this tests was to subscribe to newsletter using UI, then follow the link sent to test e-mail account using API.

### Patterns and technologies used:
* RestSharp for requests
* Page Object Model for pages and forms
* Model Classes for data
* Aquality Framework for Selenium

### Test Case
| Steps  | Expected Results |
| ------------- | ------------- |
| 1. Follow the link (https://euronews.com/)  | Main page of Euronews is opened  |
| 2. Follow the link "Newsletters" in the header  | Page "Newsletters" is opened  |
| 3. Choose a random newsletter subscription plan |	An email form has appeared at the bottom of the page |
| 4. Enter email, click "Submit" button	| You received an email with a request to confirm subscription |
| 5. Folow the link received from the letter | A page with a message about successful subscription confirmation is opened |
| 6. Click "Back to the site"	| Main page of Euronews is opened |
| 7. Follow the link "Newsletters" in the header, choose the same newsletter subscription plan as in the step 3, click "See preview" | A preview of the required plan is opened |
| 8. On preview find and get a link to unsubscribe from the mailing list, follow this link in the browser	| Unsubscribe page is opened |
| 9. Enter email, click "Submit" button	| A message that the subscription was canceled successfully appears |
| 10. Make sure that you **haven't** received an email with a message about canceling your subscription |	The letter hasn't arrived |
