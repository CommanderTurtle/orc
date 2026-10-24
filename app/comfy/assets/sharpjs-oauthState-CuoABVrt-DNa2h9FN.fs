module ComfyUI.Assets.OauthStateCuoABVrtDNa2h9FNJs

let file = """import"./rolldown-runtime-CM1DJQSe-DW4eb1zL.js";var e=`Comfy.OAuthRequestId`,t=/^[0-9a-f]{8}-[0-9a-f]{4}-[1-7][0-9a-f]{3}-[0-9a-f]{4}-[0-9a-f]{12}$/i;function n(e){return typeof e==`string`?e:null}function r(e){return t.test(e)}function i(t){let i=t.oauth_request_id,a=n(i);return a?r(a)?(sessionStorage.setItem(e,a),a):(sessionStorage.removeItem(e),null):(i!==void 0&&sessionStorage.removeItem(e),null)}function a(){let t=sessionStorage.getItem(e);return t&&r(t)?t:null}function o(){sessionStorage.removeItem(e)}export{o as n,a as r,i as t};"""

let render() = file
