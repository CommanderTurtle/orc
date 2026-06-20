module Imported.Src.AppTsx

let file = """import { HashRouter, Routes, Route } from 'react-router-dom';
import { AuthProvider } from '@/context/AuthContext';
import Layout from '@/components/Layout';
import ProtectedRoute from '@/components/ProtectedRoute';
import ScrollToTop from '@/components/ScrollToTop';
import Home from '@/pages/Home';
import Insurance from '@/pages/Insurance';
import Dashboard from '@/pages/Dashboard';
import Assets from '@/pages/Assets';
import Health from '@/pages/Health';
import TechSupport from '@/pages/TechSupport';
import Seminars from '@/pages/Seminars';
import Contact from '@/pages/Contact';
import Login from '@/pages/Login';
import Terms from '@/pages/Terms';
import Privacy from '@/pages/Privacy';
import IUL from '@/pages/IUL';
import PrivacyIdentity from '@/pages/PrivacyIdentity';
import Ideas from '@/pages/Ideas';
import Hair from '@/pages/Hair';

export default function App() {
  return (
    <HashRouter>
      <ScrollToTop />
      <AuthProvider>
        <Layout>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/insurance" element={<Insurance />} />
            <Route path="/iul" element={<IUL />} />
            <Route path="/assets" element={<Assets />} />
            <Route path="/health" element={<Health />} />
            <Route path="/tech-support" element={<TechSupport />} />
            <Route path="/seminars" element={<Seminars />} />
            <Route path="/contact" element={<Contact />} />
            <Route path="/login" element={<Login />} />
            <Route path="/privacy-identity" element={<PrivacyIdentity />} />
            <Route path="/ideas" element={<Ideas />} />
            <Route path="/hair" element={<Hair />} />
            <Route
              path="/dashboard"
              element={
                <ProtectedRoute>
                  <Dashboard />
                </ProtectedRoute>
              }
            />
            <Route path="/terms" element={<Terms />} />
            <Route path="/privacy" element={<Privacy />} />
          </Routes>
        </Layout>
      </AuthProvider>
    </HashRouter>
  );
}
"""

let render() = file
