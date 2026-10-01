# 🎤 Fearless Front VR

**Utiliser la réalité virtuelle et l'IA pour répondre à un enjeu de santé : vaincre l'anxiété de prise de parole en public.**  
*Projet développé dans le cadre du VR/AR Hackathon organisé par la Vidzeme University of Applied Sciences (Vidzemes Augstskola).*

## 📖 À propos du projet

La prise de parole en public est l'une des phobies et sources de stress les plus répandues. **Fearless Front VR** est une application immersive en réalité virtuelle conçue pour aider les utilisateurs à mieux gérer leur anxiété.

Plongé via un casque **Meta Quest 2** dans une salle de classe virtuelle, l'utilisateur fait face à une audience dynamique et réaliste. L'objectif est de recréer des conditions progressives d'exposition pour apprivoiser le trac. En fin de session, une **IA de coaching** analyse les données de la simulation pour générer un retour personnalisé.

## ✨ Fonctionnalités Clés & Architecture Technique

Développé sous **Unity 6**, le projet intègre plusieurs briques technologiques avancées :

*   **Réactions dynamiques de la foule :** Un système de gestion d'animations aléatoires et asynchrones couplé à un suivi du regard (*Inverse Kinematics*) permet à l'audience de réagir en temps réel (applaudissements, murmures, écoute attentive).
*   **Données biométriques :** Capture et suivi du rythme cardiaque en temps réel pour évaluer le niveau de stress de l'orateur.
*   **IA de Coaching :** Intégration d'un modèle d'intelligence artificielle via **Groq** et **Llama 3.3** pour débriefer la performance de l'utilisateur.
*   **Réalité Virtuelle :** Configuration **OpenXR** optimisée pour le Meta Quest 2.

## 🛠️ Stack Technique

*   **Moteur :** Unity 6 (OpenXR, XR Interaction Toolkit)
*   **Langage :** C#
*   **Intelligence Artificielle :** API Groq / Llama 3.3
*   **Matériel cible :** Meta Quest 2
*   **3D / Animation :** Formats FBX/GLTF, Rigging Humanoid (Mixamo)

## 🧠 Défis Techniques Relevés

1.  **Optimisation de la foule VR :** Centralisation de la logique d'animation via un gestionnaire C# pour éviter l'impact sur les performances du casque, tout en éliminant les bugs de "T-Poses" et de synchronisation des squelettes.
2.  **Pipeline XR & Biofeedback :** Connexion fluide entre le matériel VR, le suivi physiologique (rythme cardiaque) et les services cloud d'IA.
3.  **Immersion et Présence :** Résolution des problématiques d'importation 3D (textures, matériaux) pour garantir une esthétique propre et non-intrusive propice à la diminution du stress.

## 🚀 Installation & Utilisation

1. Clonez ce dépôt :
   ```bash
   git clone [https://github.com/JakubKula1/VR-hackathon-fearless-front.git](https://github.com/JakubKula1/VR-hackathon-fearless-front.git)
