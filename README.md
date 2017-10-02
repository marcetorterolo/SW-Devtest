Programming Test
========

Instructions
--------

* Treat this code as your own. Do whatever changes you feel necessary.
* There are several deliberate design, code quality and test issues that should be identified and resolved.
* Below is a list of the current features supported by the application; as well as some additional features that have been requested by the business owner.
* In order to work on this take a fork into your own BitBucket or GitHub area; make whatever changes you feel are necessary and when you are satisfied submit back via a pull request. See details on BitBucket's's [Fork & Pull](https://confluence.atlassian.com/bitbucket/forking-a-repository-221449527.html) model
* Refactor and add features (from the below list) as you see fit; there is no need to add all the features in order to "complete" the exercise. 
* Keep in mind that code quality is the critical measure and there should be an obvious focus on testing.
* There is no database or UI; these are not needed!
* The test should take about 2 hours, however, you're welcome to spend as much time as you like; 

Prerequisites
--------
* The project was created using Visual Studio 2017 Community Edition, but you can use older version of Visual Studio or VS Code
* The project uses .NET Framework 4.6
* External dependencies is NUnit 3.8.1 and NUnit3TestAdapter
* The project uses nuget to automatically resolve dependencies.
* NUnit GUI runner can be used to run the tests.

SharpBank
--------

Simplistic application for a retail bank. Should provide basic bank functions.

### Current Features

* A customer can open an account
* A customer can deposit / withdraw funds from an account
* A customer can request a statement that shows transactions and totals for each of their accounts
* Different accounts have interest calculated in different ways
  * **Checking accounts** have a flat rate of 0.1%
  * **Savings accounts** have a rate of 0.1% for the first $1,000 then 0.2%
  * **Maxi-Savings accounts** have a rate of 2% for the first $1,000 then 5% for the next $1,000 then 10%
* A bank manager can get a report showing the list of customers and how many accounts they have
* A bank manager can get a report showing the total interest paid by the bank on all accounts

### Additional Features

* A customer can transfer between their accounts
* Change **Maxi-Savings accounts** to have an interest rate of 5% assuming no withdrawals in the past 10 days otherwise 0.1%
* Interest rates should accrue daily (incl. weekends), rates above are per-annum