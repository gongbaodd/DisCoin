export default function Backlog() {
    return <>
    <div className="bg-[#221f20] rounded-lg shadow-md p-8 border border-yellow-900/30">
        <div className="flex items-center mb-6 text-yellow-400">
            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" className="lucide lucide-clipboard-list mr-2"><rect width="8" height="4" x="8" y="2" rx="1" ry="1"></rect><path d="M16 4h2a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2H6a2 2 0 0 1-2-2V6a2 2 0 0 1 2-2h2"></path><path d="M12 11h4"></path><path d="M12 16h4"></path><path d="M8 11h.01"></path><path d="M8 16h.01"></path></svg>
            <h2 className="text-3xl font-bold text-yellow-400">Project Backlog</h2>
        </div>

        <div className="aspect-w-16 aspect-h-9 mb-8">
            <img
                src="./backlog.png"
                alt="backlog"
                className="w-full object-cover rounded-lg"
            />
        </div>

    </div>

    <div className="bg-[#221f20] rounded-lg shadow-md p-8 border border-yellow-900/30">
        <div className="flex items-center mb-6 text-yellow-400">
            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" className="lucide lucide-clipboard-list mr-2"><rect width="8" height="4" x="8" y="2" rx="1" ry="1"></rect><path d="M16 4h2a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2H6a2 2 0 0 1-2-2V6a2 2 0 0 1 2-2h2"></path><path d="M12 11h4"></path><path d="M12 16h4"></path><path d="M8 11h.01"></path><path d="M8 16h.01"></path></svg>
            <h2 className="text-3xl font-bold text-yellow-400">Version 1</h2>
        </div>

        <div className="text-yellow-100/90 text-lg leading-relaxed mb-6 space-y-12">
        <p>
            Version 1 is a prototype build, we have the simple game mechanics and some narritive elements.
        </p>
        </div>

        <div className="aspect-w-16 aspect-h-9 mb-8">
            <img
                src="./version/v1.png"
                alt="v1"
                className="w-full object-cover rounded-lg"
            />
        </div>

    </div>

    <div className="bg-[#221f20] rounded-lg shadow-md p-8 border border-yellow-900/30">
        <div className="flex items-center mb-6 text-yellow-400">
            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" className="lucide lucide-clipboard-list mr-2"><rect width="8" height="4" x="8" y="2" rx="1" ry="1"></rect><path d="M16 4h2a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2H6a2 2 0 0 1-2-2V6a2 2 0 0 1 2-2h2"></path><path d="M12 11h4"></path><path d="M12 16h4"></path><path d="M8 11h.01"></path><path d="M8 16h.01"></path></svg>
            <h2 className="text-3xl font-bold text-yellow-400">Version 2</h2>
        </div>

        <div className="text-yellow-100/90 text-lg leading-relaxed mb-6 space-y-12">
        <p>
            Version 2 we added sprites for the game, but no opening scene and ending scene.
        </p>
        </div>

        <div className="aspect-w-16 aspect-h-9 mb-8">
            <img
                src="./version/v2.png"
                alt="v2"
                className="w-full object-cover rounded-lg"
            />
        </div>

    </div>


    <div className="bg-[#221f20] rounded-lg shadow-md p-8 border border-yellow-900/30">
        <div className="flex items-center mb-6 text-yellow-400">
            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" className="lucide lucide-clipboard-list mr-2"><rect width="8" height="4" x="8" y="2" rx="1" ry="1"></rect><path d="M16 4h2a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2H6a2 2 0 0 1-2-2V6a2 2 0 0 1 2-2h2"></path><path d="M12 11h4"></path><path d="M12 16h4"></path><path d="M8 11h.01"></path><path d="M8 16h.01"></path></svg>
            <h2 className="text-3xl font-bold text-yellow-400">Version 3</h2>
        </div>

        <div className="text-yellow-100/90 text-lg leading-relaxed mb-6 space-y-12">
        <p>
            Version 3 we made opening scene and ending scene. And we added sounds and VFX.
        </p>
        </div>

        <div className="aspect-w-16 aspect-h-9 mb-8">
            <img
                src="./version/v3-1.png"
                alt="v3"
                className="w-full object-cover rounded-lg"
            />
        </div>

        <div className="aspect-w-16 aspect-h-9 mb-8">
            <img
                src="./version/v3-2.png"
                alt="v3"
                className="w-full object-cover rounded-lg"
            />
        </div>

        <div className="aspect-w-16 aspect-h-9 mb-8">
            <img
                src="./version/v3-3.png"
                alt="v3"
                className="w-full object-cover rounded-lg"
            />
        </div>

        <div className="aspect-w-16 aspect-h-9 mb-8">
            <img
                src="./version/v3-4.png"
                alt="v3"
                className="w-full object-cover rounded-lg"
            />
        </div>

    </div>
    </>
}