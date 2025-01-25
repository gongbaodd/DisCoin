import './App.css'
import { Unity, useUnityContext } from "react-unity-webgl"

function App() {
  const { unityProvider } = useUnityContext({
    loaderUrl: "Build/Build.loader.js",
    dataUrl: "Build/Build.data.br",
    frameworkUrl: "Build/Build.framework.js.br",
    codeUrl: "Build/Build.wasm.br",
  });

  return (
    <>
      <h1>DisCoin: The Crypto Bubble Simulator</h1>
      <div className="card">
        <Unity unityProvider={unityProvider} style={{ width: 960, height: 600 }} />
      </div>
    </>
  )
}

export default App
