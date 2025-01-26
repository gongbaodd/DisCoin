import './App.css'
import { Unity, useUnityContext } from "react-unity-webgl"
import { Button } from "@/components/ui/button"
import { Card, CardContent, CardDescription, CardFooter, CardHeader, CardTitle } from "@/components/ui/card"

function App() {
  const {
    unityProvider,
    requestFullscreen,
    takeScreenshot,
  } = useUnityContext({
    loaderUrl: "Build/Build.loader.js",
    dataUrl: "Build/Build.data.br",
    frameworkUrl: "Build/Build.framework.js.br",
    codeUrl: "Build/Build.wasm.br",
    webglContextAttributes: {
      preserveDrawingBuffer: true,
    },
  });

  function handleFullScreenClick() {
    requestFullscreen(true);
  }

  function handleScreenShotClick() {
    const dataUrl = takeScreenshot("image/jpg", 1.0);

    const a: HTMLAnchorElement = document.createElement("a");
    a.href = dataUrl!;
    a.download = "screenshot.jpg";
    a.click();
  }


  return (
    <>
      <Card>
        <CardHeader>
          <CardTitle>
            <h1>DisCoin</h1>
          </CardTitle>
          <CardDescription>
            The Crypto Bubble Simulator
          </CardDescription>
        </CardHeader>
        <CardContent>
          <Unity unityProvider={unityProvider} style={{ width: 960, height: 600 }} />
        </CardContent>
        <CardFooter className="flex justify-between">
          <Button onClick={handleFullScreenClick}>Enter Fullscreen</Button>
          <Button onClick={handleScreenShotClick}>Take Screenshot</Button>
        </CardFooter>
      </Card>
    </>
  )
}

export default App
