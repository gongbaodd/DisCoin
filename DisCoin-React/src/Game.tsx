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
        <div className="space-y-12">
            <div className="rounded-lg shadow-xl overflow-hidden border border-yellow-900/30">
                <div className="flex flex-col items-center justify-center space-y-4 p-20 bg-[#221f20] game">
                    <Unity unityProvider={unityProvider} style={{ width: 960, height: 600 }} />
                </div>

                <div className="flex justify-between items-center mt-8 px-20 pb-14">
                    <button className="flex items-center px-6 py-3 bg-yellow-600 text-gray-900 rounded-lg hover:bg-yellow-500 transition-colors duration-200 shadow-lg group font-semibold"
                        onClick={handleFullScreenClick}
                    >
                        <span className="mr-2">Enter Fullscreen</span>
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" className="lucide lucide-maximize2 w-4 h-4 group-hover:scale-110 transition-transform duration-200"><polyline points="15 3 21 3 21 9"></polyline><polyline points="9 21 3 21 3 15"></polyline><line x1="21" x2="14" y1="3" y2="10"></line><line x1="3" x2="10" y1="21" y2="14"></line></svg>
                    </button>
                    <button className="flex items-center px-6 py-3 bg-yellow-500 text-gray-900 rounded-lg hover:bg-yellow-400 transition-colors duration-200 shadow-lg group font-semibold"
                        onClick={handleScreenShotClick}
                    >
                        <span className="mr-2">Take Screenshot</span>
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" className="lucide lucide-camera w-4 h-4 group-hover:scale-110 transition-transform duration-200"><path d="M14.5 4h-5L7 7H4a2 2 0 0 0-2 2v9a2 2 0 0 0 2 2h16a2 2 0 0 0 2-2V9a2 2 0 0 0-2-2h-3l-2.5-3z"></path><circle cx="12" cy="13" r="3"></circle></svg>
                    </button>
                </div>
            </div>


            <div className="bg-[#221f20] rounded-lg shadow-md p-8 border border-yellow-900/30">
                <h2 className="text-3xl font-bold text-gray-900 mb-4 text-yellow-400">Description</h2>
                <div className="text-yellow-100/90 text-lg leading-relaxed mb-6 space-y-12">
                    <p>
                        Step into the dark world of crypto speculation as a "crypto bro" manufacturing a wave of disinformation to manipulate the market. In DisCoin, you'll select news stories, amplify or dismiss them, and spin lies to sway public opinion, rocketing your memecoin to the moon.
                    </p>
                    <p>
                        Dismiss stories, distort the truth, create distractions, and sow dismay to sway gullible masses. With every click, the coin value fluctuates. Maintain the perfect bubble and rake in millions before pulling the rug, or watch it burst and face the consequences.
                    </p>
                    <p>
                        Featuring glowing screen ambiance, the subtle whir of GPU fans, and frantic decision-making, DisCoin challenges you to keep the $BUBBLE alive—or pop it. Can you master the game of deception, or will your memecoin, and your reputation, crash to zero?
                    </p>
                </div>

            </div>
        </div>

    )
}

export default Game
