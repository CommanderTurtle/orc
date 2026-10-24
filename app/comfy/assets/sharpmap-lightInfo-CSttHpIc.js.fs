module ComfyUI.Assets.LightInfoCSttHpIcJsMap

let file = """{"version":3,"file":"lightInfo-CSttHpIc.js","names":[],"sources":["../../src/extensions/core/lightInfo.ts"],"sourcesContent":["import { useExtensionService } from '@/services/extensionService'\n\nuseExtensionService().registerExtension({\n  name: 'Comfy.CreateLightInfo',\n\n  nodeCreated(node) {\n    if (node.constructor.comfyClass !== 'CreateLightInfo') return\n\n    const [oldWidth, oldHeight] = node.size\n    node.setSize([Math.max(oldWidth, 360), Math.max(oldHeight, 580)])\n  }\n})\n"],"mappings":"6FAEA,EAAoB,CAAC,CAAC,kBAAkB,CACtC,KAAM,wBAEN,YAAY,EAAM,CAChB,GAAI,EAAK,YAAY,aAAe,kBAAmB,OAEvD,GAAM,CAAC,EAAU,GAAa,EAAK,KACnC,EAAK,QAAQ,CAAC,KAAK,IAAI,EAAU,GAAG,EAAG,KAAK,IAAI,EAAW,GAAG,CAAC,CAAC,CAClE,CACF,CAAC"}"""

let render() = file
