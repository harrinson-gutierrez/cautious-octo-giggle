﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdaIntelligenceApi.Resources.Resources {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class SharedResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SharedResources() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AdaIntelligenceApi.Resources.Resources.SharedResources", typeof(SharedResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Confirmar cuenta de usuario.
        /// </summary>
        internal static string EmailConfirmedAccountSubject {
            get {
                return ResourceManager.GetString("EmailConfirmedAccountSubject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a ADA-ConfirmAccount-En.
        /// </summary>
        internal static string EmailConfirmedAccountTemplate {
            get {
                return ResourceManager.GetString("EmailConfirmedAccountTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Recuperación de contraseña.
        /// </summary>
        internal static string EmailRecoveryPasswordSubject {
            get {
                return ResourceManager.GetString("EmailRecoveryPasswordSubject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a ADA-RecoveryPassword-En.
        /// </summary>
        internal static string EmailRecoveryPasswordTemplate {
            get {
                return ResourceManager.GetString("EmailRecoveryPasswordTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El correo no ha sido confirmado.
        /// </summary>
        internal static string ExceptionInvalidRequestEmailNotConfirmed {
            get {
                return ResourceManager.GetString("ExceptionInvalidRequestEmailNotConfirmed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a GrantType no encontrado Password o RefreshToken.
        /// </summary>
        internal static string ExceptionInvalidRequestGrantTypeNotFound {
            get {
                return ResourceManager.GetString("ExceptionInvalidRequestGrantTypeNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El token de acceso no ha expirado aun.
        /// </summary>
        internal static string ExceptionInvalidRequestHasntExpired {
            get {
                return ResourceManager.GetString("ExceptionInvalidRequestHasntExpired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Token invalido.
        /// </summary>
        internal static string ExceptionInvalidRequestInvalidToken {
            get {
                return ResourceManager.GetString("ExceptionInvalidRequestInvalidToken", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El token de refrescar ya expiro.
        /// </summary>
        internal static string ExceptionInvalidRequestRefreshTokenExpired {
            get {
                return ResourceManager.GetString("ExceptionInvalidRequestRefreshTokenExpired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El token de refrescar ya ha sido usado.
        /// </summary>
        internal static string ExceptionInvalidRequestRefreshTokenHasUsed {
            get {
                return ResourceManager.GetString("ExceptionInvalidRequestRefreshTokenHasUsed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El token de refrescar ha sido invalidado.
        /// </summary>
        internal static string ExceptionInvalidRequestRefreshTokenInvalidated {
            get {
                return ResourceManager.GetString("ExceptionInvalidRequestRefreshTokenInvalidated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El token de refrescar sesion no existe.
        /// </summary>
        internal static string ExceptionInvalidRequestRefreshTokenNotExists {
            get {
                return ResourceManager.GetString("ExceptionInvalidRequestRefreshTokenNotExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El token de refrescar no concuerda con el token de acceso.
        /// </summary>
        internal static string ExceptionInvalidRequestRefreshTokenNotMatch {
            get {
                return ResourceManager.GetString("ExceptionInvalidRequestRefreshTokenNotMatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El Usuario {0} ya se encuentra registrado.
        /// </summary>
        internal static string ExceptionInvalidRequestRepeatUser {
            get {
                return ResourceManager.GetString("ExceptionInvalidRequestRepeatUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Usuario y/o contraseña incorrectos.
        /// </summary>
        internal static string ExceptionUnauthorizedUser {
            get {
                return ResourceManager.GetString("ExceptionUnauthorizedUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Usuario no encontrado {0}.
        /// </summary>
        internal static string ExceptionUserNotFound {
            get {
                return ResourceManager.GetString("ExceptionUserNotFound", resourceCulture);
            }
        }
    }
}
