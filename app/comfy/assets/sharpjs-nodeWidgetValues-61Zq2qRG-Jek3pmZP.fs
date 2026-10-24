module ComfyUI.Assets.NodeWidgetValues61Zq2qRGJek3pmZPJs

let file = """import"./rolldown-runtime-CM1DJQSe-DW4eb1zL.js";import{i as e,or as t}from"./nodeDefStore-B8cjfdeD-CJqS0EUr.js";function n(e,n){let r=e.graph?.rootGraph.id;return r?t(r,e.id,n):null}function r(t,r){let i=n(t,r),a=i?e().getWidget(i):void 0;return a?a.value:t.widgets?.find(e=>e.name===r)?.value}function i(t,i,a){let o=n(t,i),s=t.widgets?.find(e=>e.name===i),c=r(t,i);return o&&e().setValue(o,a)?(s&&(s.value=a,s.callback?.(a),t.onWidgetChanged?.(i,a,c,s)),!0):s?(s.value=a,s.callback?.(a),t.onWidgetChanged?.(i,a,c,s),!0):!1}export{i as n,r as t};"""

let render() = file
