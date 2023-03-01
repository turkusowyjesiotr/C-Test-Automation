## Internship Examination Task

This project was verified by my mentor at a1qa company's internal exam for interns. It simulated working at real life project, including contacting project lead for questions regarding incomplete information about test case and writing daily reports.

To do this project I deployed **Docker** locally using **WSL2** to run company's internal application there. Then, my task was to use API requests to generate token, pass this token as cookie to the application. Then do some UI tests as described in the test case below.

### Patterns and technologies used:
* Docker
* NUnit as test framework
* RestSharp for requests
* Page Object Model for pages and forms
* Model Classes for data
* Aquality Framework for Selenium

### Test Case
| Steps  | Expected Results |
| ------------- | ------------- |
| 1. Get a token according to the variant number (2) using API request  | Token was generated |
| 2. Go to the application's website<br>Pass the authorization<br>Pass the token generated in step 1 as cookie<br>Refresh the page | Projects page was opened<br>Footer contains correct variant number after refreshing |
| 3. Go to the "Nexage" project page<br>Get a list of tests in JSON format using API request | The tests on the first page are sorted in descending order by date and correspond to those returned by API request |
| 4. Return to the previous page in the browser<br>Click on "+Add" button<br>Enter a project name and save<br>Close opened new tab<br>Refresh the page | New page with information about succesful saving appeared after saving the proejct<br>New tab was closed<br>The project appeared in the list after refreshing |
| 5. Go to created project page<br>Add a test using API (alongside with log and current page screenshot) | Test was displayed **without** refreshing the page |

