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
    close browser

EnterExpenseForPhoneBill
    open browser  ${url}     ${browser}
    maximize browser window
    input text  id:username     vamsi.allu@gmail.com
    input text  id:password     Vamse@0220
    click element  xpath:/html/body/div/main/div/form/button
    element text should be  xpath:/html/body/div/main/div/h1       Calculate Expense
    input text  xpath:/html/body/div/main/div/form/input[1]     40
    Click Element   xpath:/html/body/div/main/div/form/select
    Mouse Down    xpath:/html/body/div/main/div/form/select/option[2]
    Click Element  xpath:/html/body/div/main/div/form/select/option[2]
    click element   xpath:/html/body/div/main/div/form/button
    close browser

*** Keywords ***
loginWithInValidUserNameAndPassword
    input text  id:id_username  Cambrian_Test
    input text  id:id_password  MNGTwdf386
    click element  xpath://*[@id="loginForm"]/input[4]