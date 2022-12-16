*** Settings ***
Library     SeleniumLibrary

*** Variables ***
${browser}  chrome
${url}  https://localhost:7068/

*** Test Cases ***
EnterExpenseWithDefaultDropDwonValue
    open browser  ${url}     ${browser}
    maximize browser window
    input text  id:username     vamsi.allu@gmail.com
    input text  id:password     Vamse@0220
    click element  xpath:/html/body/div/main/div/form/button
    element text should be  xpath:/html/body/div/main/div/h1       Calculate Expense
    input text  xpath:/html/body/div/main/div/form/input[1]     30
    click element   xpath:/html/body/div/main/div/form/button
    click element   xpath:/html/body/div/main/div/button
    element text should be  xpath:/html/body/div/main/div/h1        View Expenses
    close browser
