<login-ui>
    <!--<div class="spinBox animated fadeIn" if={loggingIn} >
        <div class="spinSpin">
            <div style="padding-left: 2px" uk-spinner="ratio: 0.5"></div>
        </div>
    </div>-->
    <div class="loginContainer animated jackInTheBox">
        
        <div class="loginBox">
            <form onsubmit="{ loginSubmit }">
                <fieldset class="uk-fieldset">
                    <div if={loginFailed}>{ this.loginFailedText }</div>
                    <div class="uk-margin">
                        <div class="uk-inline" style="width: 100%">
                            <span class="uk-form-icon" uk-icon="icon: user"></span>
                            <input ref="username" class="uk-input" type="text" placeholder="Benutzername" autofocus required>
                        </div>
                    </div>
                    <div class="uk-margin">
                        <div class="uk-inline" style="width: 100%">
                            <span class="uk-form-icon" uk-icon="icon: lock"></span>
                            <input ref="password" class="uk-input" type="password" placeholder="Passwort" required>
                        </div>
                    </div>
                    <button disabled={loggingIn} class="uk-button uk-button-primary uk-button-small">{ this.loginText }</button>
                </fieldset>
            </form>
        </div>
    </div>
    <script>

        this.loginText = "Anmelden";
        this.loggingIn = false;
        this.loginFailed = false;
        this.loginFailedText = "";
        loginSubmit(e){
            e.preventDefault();
            this.loginFailed = false;
            if(this.loggingIn) {
               throw new Error('Sign in process already running!');
            }
            this.loggingIn = true;
            
            mp.trigger("Browser:Login", this.refs.username.value, this.refs.password.value);
            this.loginText = "Logging in...";
            console.log("Logging in...");
            this.update();
        }

        document.addEventListener("loginFailed", (ev) => {
            this.loginFailed = true;
            this.loggingIn = false;
            this.loginText = "Anmelden";
            this.loginFailedText = ev.detail.reason;
     
            this.update();
        });

    </script>
    <style>
        .spinSpin {
            display: block;
            margin-left: auto;
            margin-right: auto;
            width: 50%;
            position: relative;
            padding-top: 10%;
        }
        .spinBox {
            position: fixed; /* Positionierung an Viewport */
            width: 100%; /* Volle Breite */
            height: 100%; /* Volle Hoehe */
            z-index: 100; /* Ueber andere Elementen legen */
            background-color: rgba(0, 0, 0, 0.4);
        }
        .loginBox {
            background-color: rgba(0, 0, 0, 0.5);
            color: white;
            padding: 15px;
            box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
            border-radius: 3px;
        }
        .loginContainer {
            z-index:	1;
            max-width: 400px;
            margin: auto;
            position: relative;
            padding-top: 20%;
        }
        .center {
            display: block;
            margin-left: auto;
            margin-right: auto;
            width: 50%;
        }
        body {
            background-color: transparent;
        }
        .uk-button-danger:disabled, .uk-button-default:disabled, .uk-button-primary:disabled, .uk-button-secondary:disabled {
            background-color: rgba(0, 0, 0, 0.37);
            color: #fff;
            border-color: rgba(156, 156, 156, 0);
        }

    </style>
</login-ui>