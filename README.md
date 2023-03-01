## Userinyerface Project

This project aims to automate UI tests on the https://userinyerface.com/ website, which is designed as anti-user experience.

Goal of this project was to conduct a couple of simple UI tests on badly designed websited and find a work-around for file upload on website with no proper file upload tag/form.

### Patterns and technologies used:
* Page Object Model for pages and forms
* Aquality Framework for Selenium

### Test Case 1 (LoginTest)
| Steps  | Expected Results |
| ------------- | ------------- |
| 1. Navigate to home page  | Welcome page is open |
| 2. Click the link (in text 'Please click HERE to GO to the next page') to navigate the next page  | The '1' card is open |
| 3. Input random valid password, email, accept the terms of use and click "next" button | The '2' card is open |
| 4. Choose 2 random interests, upload image, click "Next" button	| The '3' card is open |

### Test Case 2 (HideHelpFormTest)
| Steps  | Expected Results |
| ------------- | ------------- |
| 1. Navigate to home page  | Welcome page is open |
| 2. Hide help form | Form content is hidden |

### Test Case 3 (CookiesFormTest)
| Steps  | Expected Results |
| ------------- | ------------- |
| 1. Navigate to home page  | Welcome page is open |
| 2. Accept cookies | Form is closed |


### Test Case 4 (TimerTest)
| Steps  | Expected Results |
| ------------- | ------------- |
| 1. Navigate to home page  | Validate that timer starts from "00:00" |

