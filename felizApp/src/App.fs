module App

open Feliz
open Zanaptak.TypedCssClasses

type FA = CssClasses<"https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css", Naming.PascalCase>
type BS = CssClasses<"https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css", Naming.PascalCase>

type CounterProps = { Value: int }

let counter = React.functionComponent(fun (input: CounterProps) ->
    let (count, setCount) = React.useState(input.Value)
    Html.div [
        Html.h1 count
        Html.button [
            prop.text "Increment"
            prop.onClick (fun _ -> setCount(count + 1))
        ]
    ])

let loginButton = React.functionComponent(fun (login: {| User: string; Password: string|}) ->
    let (modalIsActive, setModalActive) = React.useState(false)

    let display = 
        match modalIsActive with
        |true -> style.display.block
        |false -> style.display.none

    Html.div [
        Html.button [
            prop.className "button-info"
            prop.text "Login"
            prop.onClick (fun _ -> setModalActive(true))
        ]
        Html.div [
            prop.text "Login"
            prop.className "modal"
            prop.style [
                display  
                style.zIndex 1
                style.position.fixedRelativeToWindow
                style.paddingTop (length.px 100)
                style.left 0
                style.top 0
                style.overflow.auto
                style.width (length.percent 100)
                style.height (length.percent 100)
                style.backgroundColor "rgba(0,0,0,0.4)"
            ]
            prop.children [
                Html.div [
                    prop.className "modal-content"
                    prop.children [
                        Html.span [ 
                            prop.text "x" 
                            prop.className "close"
                            prop.onClick (fun _ -> setModalActive(false))
                            prop.style [
                                style.floatStyle.right
                                style.fontSize 28
                                style.fontWeight.bold
                            ]
                        ]
                        Html.span "password"
                        Html.input [
                            prop.className "input-pwd"
                            prop.valueOrDefault login.Password // string
                            prop.type'.password
                        ]
                        Html.span "user"
                        Html.input [
                            prop.className "input-usr"
                            prop.valueOrDefault login.User // string
                            prop.type'.text
                        ]
                    ]
                    prop.style [
                        style.margin.auto
                        style.padding (length.px 20)
                        style.border (1, borderStyle.solid, color.aliceBlue)
                        style.width (length.percent 80)
                        style.backgroundColor color.whiteSmoke
                        style.fontSize 20
                    ]
                ]
            ]
        ]
    ])

let app = React.functionComponent(fun () ->
    let (credentials, setCredentials) = React.useState({| User = ""; Password = ""|})
    let (clicked, setClick) = React.useState(false)

    Html.div [
        prop.style [
            style.textAlign.center
            style.marginLeft length.auto
            style.marginRight length.auto
            style.marginTop 50
            style.backgroundColor "pink"
            style.overflow.auto
        ]
        prop.className "App"
        prop.children [
            Html.header [ 
                prop.className "App-header" 
                prop.children [
                    Html.h1 "ACME INC"
                    Html.br []
                    loginButton {| Password = ""; User = "" |}
                ]
            ]
            Html.article [
               prop.className "App-content"
               prop.children [
                    Html.h1 "Content"
                    Html.br []
                    Html.input [
                        prop.className "input"
                        prop.valueOrDefault credentials.Password // string
                        prop.type'.password
                    ]
                    Html.input [
                        prop.className "input checkbox"
                        prop.valueOrDefault clicked // boolean
                        prop.onChange setClick // (bool -> unit)
                        prop.type'.checkbox
                    ]

                    
               ]
            ]
            
        ]
    ])

open Browser.Dom

ReactDOM.render(app, document.getElementById "feliz-app")