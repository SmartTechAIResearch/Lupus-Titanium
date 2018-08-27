/*
 * 2009 Sizing Servers Lab, affiliated with IT bachelor degree NMCT
 * University College of West-Flanders, Department GKG (www.sizingservers.be, www.nmct.be, www.howest.be/en)
 * 
 * Author(s):
 *    Dieter Vandroemme
 */

using System;
using System.Threading;

namespace Lupus_Titanium {
    public static class SynchronizationContextWrapper {
        private static SynchronizationContext _synchronizationContext;

        /// <summary>
        ///     To synchronize to the main thread (SynchronizationContext.Send/.Post).
        /// </summary>
        public static SynchronizationContext SynchronizationContext {
            get {
                if (_synchronizationContext == null) _synchronizationContext = SynchronizationContext.Current;
                return _synchronizationContext;
            }
            set {
                if (value == null)
                    throw new NullReferenceException(
                        "Try assigning SynchronizationContext.Current to this value, one is automaticaly created together with the handle of the first form. AKA, set this when the HandleCreated event of your main form is invoked.");
                _synchronizationContext = value;
            }
        }
    }
}