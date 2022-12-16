*** Settings ***
Library     SeleniumLibrary

*** Variables ***
${browser}  chrome
${url}  https://localhost:7068/

*** Test Cases ***
NavigateToRegisterPage
    open browser  ${url}     ${browser}
    maximize browser window
    click element  xpath://html/body/div/main/div/button
    element text should be  xpath://html/body/div/main/div/h1       Register New User
    close browser

RegisterWithInvalidMail
    open browser  ${url}     ${browser}
    maximize browser window
    click element  xpath://html/body/div/main/div/button
    element text should be  xpath://html/body/div/main/div/h1       Register New User
    input text  xpath:/html/body/div/main/div/form/input[1]     Fname
    input text  xpath:/html/body/div/main/div/form/input[2]     Lname
    input text  xpath:/html/body/div/main/div/form/input[3]     Fname.com
    input password  xpath:/html/body/div/main/div/form/input[4]     Fname@123
    input password  xpath:/html/body/div/main/div/form/input[5]     Fname@123
    click element  xpath:/html/body/div/main/div/form/button
    element text should be  xpath://html/body/div/main/div/h1       Register New User
    close browser

RegisterWithInvalidPassword
    open browser  ${url}     ${browser}
    maximize browser window
    click element  xpath://html/body/div/main/div/button
    element text should be  xpath://html/body/div/main/div/h1       Register New User
    input text  xpath:/html/body/div/main/div/form/input[1]     Fname
    input text  xpath:/html/body/div/main/div/form/input[2]     Lname
    input text  xpath:/html/body/div/main/div/form/input[3]     Fname@gmail.com
    click element  xpath:/html/body/div/main/div/form/button
    element text should be  xpath://html/body/div/main/div/h1       Register New User
    close browser

RegisterWithInvalidFirstName
    open browser  ${url}     ${browser}
    maximize browser window
    click element  xpath://html/body/div/main/div/button
    element text should be  xpath://html/body/div/main/div/h1       Register New User
    input text  xpath:/html/body/div/main/div/form/input[2]     Lname
    input text  xpath:/html/body/div/main/div/form/input[3]     Fname.com
    input password  xpath:/html/body/div/main/div/form/input[4]     Fname@123
    input password  xpath:/html/body/div/main/div/form/input[5]     Fname@123
    click element  xpath:/html/body/div/main/div/form/button
    element text should be  xpath://html/body/div/main/div/h1       Register New User
    close browser

RegisterWithInvalidLastName
    open browser  ${url}     ${browser}
    maximize browser window
    click element  xpath://html/body/div/main/div/button
    element text should be  xpath://html/body/div/main/div/h1       Register New User
    input text  xpath:/html/body/div/main/div/form/input[1]     Fname
    input text  xpath:/html/body/div/main/div/form/input[3]     Fname.com
    input password  xpath:/html/body/div/main/div/form/input[4]     Fname@123
    input password  xpath:/html/body/div/main/div/form/input[5]     Fname@123
    click element  xpath:/html/body/div/main/div/form/button
    element text should be  xpath://html/body/div/main/div/h1       Register New User
    close browser

RegisterWithValidData
    open browser  ${url}     ${browser}
    maximize browser window
    click element  xpath://html/body/div/main/div/button
    element text should be  xpath://html/body/div/main/div/h1       Register New User
    input text  xpath:/html/body/div/main/div/form/input[1]     Fname
    input text  xpath:/html/body/div/main/div/form/input[2]     Lname
    input text  xpath:/html/body/div/main/div/form/input[3]     Fname@gmail.com
    input password  xpath:/html/body/div/main/div/form/input[4]     Fname@123
    input password  xpath:/html/body/div/main/div/form/input[5]     Fname@123
    click element  xpath:/html/body/div/main/div/form/button
    element text should be  xpath:/html/body/div/main/div/h1        Login
    close browser