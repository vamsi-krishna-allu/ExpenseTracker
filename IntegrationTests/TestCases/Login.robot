*** Settings ***
Library     SeleniumLibrary

*** Variables ***
${browser}  chrome
${url}  https://localhost:7068/

*** Test Cases ***
LoginWithInvalidUserName
    open browser  ${url}     ${browser}
    maximize browser window
    input text  id:username     vamsi
    input text  id:password     test
    click element  xpath://html/body/div/main/div/form/button
    element text should be  xpath://html/body/div/main/div/h1       Login
    close browser

LoginWithInvalidPassword
    open browser  ${url}     ${browser}
    maximize browser window
    input text  id:username     vamsi@gmail.com
    input text  id:password     test
    click element  xpath://html/body/div/main/div/form/button
    element text should be  xpath://html/body/div/main/div/h1       Login
    close browser

LoginWithInValidUser
    open browser  ${url}     ${browser}
    maximize browser window
    input text  id:username     vamsi@gmail.com
    input text  id:password     Teste@0220
    click element  xpath:/html/body/div/main/div/form/button
    element text should be  xpath://html/body/div/main/div/h1       Login
    close browser

LoginWithValidUser
    open browser  ${url}     ${browser}
    maximize browser window
    input text  id:username     vamsi.allu@gmail.com
    input text  id:password     Vamse@0220
    click element  xpath:/html/body/div/main/div/form/button
    element text should be  xpath:/html/body/div/main/div/h1       Calculate Expense
    close browser

*** Keywords ***
loginWithInValidUserNameAndPassword
    input text  id:id_username  Cambrian_Test
    input text  id:id_password  MNGTwdf386
    click element  xpath://*[@id="loginForm"]/input[4]