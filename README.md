## MySQL Database Project

This project is a simple CRUD application that aims to simulate creating, getting and updating test results in company's database. I deployed MySQL server locally and restored database from dump file, it was already populated with mock test projects, authors and tests. I cannot provide this database dump here as it was part of my internship.

Goal of this tests was to work with this database using C#.

### Patterns and technologies used:
* NUnit as test framework
* MySQL package for C#
* Model Classes for data

### Test Case 1
| Steps  | Expected Results |
| ------------- | ------------- |
| 1. Run any tests  | The tests were executed  |
| Postconditions |
| Add a result of each completed test in the database as a new record in the corresponding table |  Information is added  |

### Test Case 2
| Preconditions |
| 1. Select tests from the database where ID contains two random repeating digits, for example "11" or "77". But no more than 10 tests. |
| 2. Copy these tests with an indication of the current project and the author. |
| Steps  | Expected Results |
| 1. Simulate the launch of each test. Update information about them in the database.  | Tests are completed, information is updated.  |
| Postconditions |
| 1. Delete the records created in Preconditions from the database. |  The records have been deleted. |

