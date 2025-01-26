import { Unity, useUnityContext } from "react-unity-webgl"

function Game() {
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

            <Unity unityProvider={unityProvider} style={{ width: 960, height: 600 }} />

            <button onClick={handleFullScreenClick}>Enter Fullscreen</button>
            <button onClick={handleScreenShotClick}>Take Screenshot</button>

        </>
    )
}

export default Game
