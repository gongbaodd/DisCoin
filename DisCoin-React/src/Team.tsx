export default function Team() {
    return (
        <div className="bg-[#221f20] rounded-lg shadow p-8 border border-yellow-900/30">
            <h2 className="text-3xl font-bold text-yellow-400 mb-8">Our Team</h2>
            <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
                {[
                    {
                        name: 'Gong',
                        role: 'Programmer',
                        image: 'https://globalgamejam.org/sites/default/files/styles/sidebar_full/public/pictures/2024-12/download.png?itok=9gTf5Zh7',
                    },
                    {
                        name: 'martinwachira',
                        role: 'Programmer',
                        image: 'https://globalgamejam.org/sites/default/files/styles/sidebar_full/public/pictures/2025-01/rb_80328.png?itok=4tt09t_X',
                    },
                    {
                        name: 'Unrealyiqi',
                        role: 'Designer',
                        image: 'https://globalgamejam.org/themes/custom/ggj_v4/assets/img/icon_person-circle.svg',
                    },
                    {
                        name: 'GeorgeABoyle',
                        role: 'Designer & Narrator',
                        image: 'https://globalgamejam.org/themes/custom/ggj_v4/assets/img/icon_person-circle.svg',
                    },
                    {
                        name: 'tonykoc',
                        role: 'Narrator',
                        image: 'https://globalgamejam.org/sites/default/files/styles/sidebar_full/public/pictures/2025-01/54126553029_dfeda80f45_o.jpeg?itok=4sQJW29y',
                    },
                ].map((member) => (
                    <div key={member.name} className="text-center">
                        <img
                            src={member.image}
                            alt={member.name}
                            className="w-32 h-32 rounded-full mx-auto mb-4 object-cover"
                        />
                        <h3 className="text-xl font-semibold text-yellow-400">{member.name}</h3>
                        <p className="text-yellow-200/70">{member.role}</p>
                    </div>
                ))}
            </div>
        </div>
    )
}