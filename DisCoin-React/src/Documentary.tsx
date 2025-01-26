import Prototype from "./Prototype"

export default function Documentary() {
    return <div className="space-y-12">
    <div className="bg-[#221f20] rounded-lg shadow p-8 border border-yellow-900/30">
        <div className="aspect-w-16 aspect-h-9 mb-8">
            <img
                src="./photos/group-photo.jpg"
                alt="Group photo"
                className="w-full h-[400px] object-cover rounded-lg"
            />
        </div>
        <h2 className="text-3xl font-bold text-gray-900 mb-4 text-yellow-400">Our Story</h2>
    </div>
    <Prototype />
    </div>
}