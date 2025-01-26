import React, { useState } from 'react';
import { Home, Users, Film } from 'lucide-react';
import Game from './Game';
import Team from './Team';

type Tab = 'home' | 'team' | 'documentary';

function App() {
  const [activeTab, setActiveTab] = useState<Tab>('home');

  const tabs = [
    { id: 'home', label: 'Home', icon: Home },
    { id: 'team', label: 'Team', icon: Users },
    { id: 'documentary', label: 'Documentary', icon: Film },
  ] as const;

  return (
    <div className="min-h-screen bg-gray-900">
      {/* Header */}
      <header className="shadow-sm border-yellow-900/30">
        <nav className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="flex justify-between h-16">
            <div className="flex space-x-8">
              {tabs.map((tab) => {
                const Icon = tab.icon;
                return (
                  <button
                    key={tab.id}
                    onClick={() => setActiveTab(tab.id)}
                    className={`inline-flex items-center px-1 pt-1 border-b-2 text-sm font-medium ${activeTab === tab.id
                        ? 'border-yellow-500 text-yellow-400'
                        : 'border-transparent text-gray-400 hover:border-yellow-700 hover:text-yellow-600'
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
          <Game />
        )}

        {activeTab === 'team' && (
          <Team />
        )}

        {activeTab === 'documentary' && (
          <div className="bg-gray-800 rounded-lg shadow p-8">
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