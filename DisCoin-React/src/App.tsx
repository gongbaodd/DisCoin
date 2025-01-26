import React, { useState } from 'react';
import { Home, Users, Film } from 'lucide-react';
import Game from './Game';

type Tab = 'home' | 'team' | 'documentary';

function App() {
  const [activeTab, setActiveTab] = useState<Tab>('home');

  const tabs = [
    { id: 'home', label: 'Home', icon: Home },
    { id: 'team', label: 'Team', icon: Users },
    { id: 'documentary', label: 'Documentary', icon: Film },
  ] as const;

  return (
    <div className="min-h-screen bg-gray-50">
      {/* Header */}
      <header className="bg-white shadow-sm">
        <nav className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="flex justify-between h-16">
            <div className="flex space-x-8">
              {tabs.map((tab) => {
                const Icon = tab.icon;
                return (
                  <button
                    key={tab.id}
                    onClick={() => setActiveTab(tab.id)}
                    className={`inline-flex items-center px-1 pt-1 border-b-2 text-sm font-medium ${
                      activeTab === tab.id
                        ? 'border-indigo-500 text-gray-900'
                        : 'border-transparent text-gray-500 hover:border-gray-300 hover:text-gray-700'
                    }`}
                  >
                    <Icon className="w-4 h-4 mr-2" />
                    {tab.label}
                  </button>
                );
              })}
            </div>
          </div>
        </nav>
      </header>

      {/* Content */}
      <main className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-12">
        {activeTab === 'home' && (
          <div className="bg-white rounded-lg shadow-xl overflow-hidden">
                <Game />
          </div>
        )}

        {activeTab === 'team' && (
          <div className="bg-white rounded-lg shadow p-8">
            <h2 className="text-3xl font-bold text-gray-900 mb-8">Our Team</h2>
            <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
              {[
                {
                  name: 'Sarah Johnson',
                  role: 'CEO',
                  image: 'https://images.unsplash.com/photo-1494790108377-be9c29b29330?auto=format&fit=crop&w=800&q=80',
                },
                {
                  name: 'Michael Chen',
                  role: 'CTO',
                  image: 'https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?auto=format&fit=crop&w=800&q=80',
                },
                {
                  name: 'Emily Rodriguez',
                  role: 'Design Director',
                  image: 'https://images.unsplash.com/photo-1438761681033-6461ffad8d80?auto=format&fit=crop&w=800&q=80',
                },
              ].map((member) => (
                <div key={member.name} className="text-center">
                  <img
                    src={member.image}
                    alt={member.name}
                    className="w-32 h-32 rounded-full mx-auto mb-4 object-cover"
                  />
                  <h3 className="text-xl font-semibold text-gray-900">{member.name}</h3>
                  <p className="text-gray-500">{member.role}</p>
                </div>
              ))}
            </div>
          </div>
        )}

        {activeTab === 'documentary' && (
          <div className="bg-white rounded-lg shadow p-8">
            <div className="aspect-w-16 aspect-h-9 mb-8">
              <img
                src="https://images.unsplash.com/photo-1485846234645-a62644f84728?auto=format&fit=crop&w=2850&q=80"
                alt="Documentary cover"
                className="w-full h-[400px] object-cover rounded-lg"
              />
            </div>
            <h2 className="text-3xl font-bold text-gray-900 mb-4">Our Story</h2>
            <p className="text-gray-600 leading-relaxed">
              Follow our journey as we transform the industry through innovation and dedication.
              This documentary showcases our team's commitment to excellence and the impact
              we've made in the lives of our customers.
            </p>
          </div>
        )}
      </main>
    </div>
  );
}

export default App;