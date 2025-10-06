using IctApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace IctApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Stages.Any())
            {
                return; // DB has been seeded
            }

            var secondaryStage = new Stage
            {
                Title = "المرحلة الثانوية",
                Grades = new List<Grade>()
            };

            var thirdGrade = new Grade
            {
                Title = "الصف الثالث الثانوي",
                Stage = secondaryStage,
                Units = new List<Unit>
                {
                    // Unit 1
                    new Unit
                    {
                        Title = "الوحدة الأولى: البرمجة والذكاء الاصطناعي",
                        Lessons = new List<Lesson>
                        {
                            new Lesson {
                                Title = "المعلومات والوسائط",
                                Content = @"
                                    <h3>البيانات، المعلومات، والمعرفة:</h3>
                                    <ul>
                                        <li><b>البيانات (Data):</b> هي حقائق يتم تمثيلها باستخدام الأرقام أو الأحرف أو الرموز.</li>
                                        <li><b>المعلومات (Information):</b> هي المعنى أو القيمة التي تُستخدم لاتخاذ القرار، وليس لها شكل أو كيان ثابت.</li>
                                        <li><b>المعرفة (Knowledge):</b> هي المعلومات التي تم تحليلها وتنظيمها بشكل منهجي للمساعدة في حل المشكلات.</li>
                                    </ul>
                                    <h3>خصائص المعلومات:</h3>
                                    <ul>
                                        <li><b>الاستمرارية (Persistence):</b> لا يمكن محوها بالكامل بمجرد إنشائها.</li>
                                        <li><b>قابلية التكرار (Reproducibility):</b> إمكانية نسخها بسهولة.</li>
                                        <li><b>الانتشار (Propagation):</b> سهولة توصيلها ونشرها عبر الإنترنت ووسائل الإعلام الجماهيرية.</li>
                                    </ul>
                                    <h3>أنواع المعلومات:</h3>
                                    <ul>
                                        <li><b>معلومات أولية:</b> تُحصل من تجربة شخصية مباشرة أو بحث وتجارب.</li>
                                        <li><b>معلومات ثانوية:</b> تُحصل من طرف ثالث، مثل الكتب والصحف. ويتطلب التحقق المتبادل (Cross-checking) لتحديد دقتها.</li>
                                    </ul>
                                    <h3>الوسائط (Media):</h3>
                                    <p>هي وسائل لنقل المعلومات. وتشمل:</p>
                                    <ul>
                                        <li><b>وسائط التعبير:</b> مثل النص والصوت.</li>
                                        <li><b>وسائط النقل/الإرسال:</b> مثل التلفزيون والإنترنت.</li>
                                        <li><b>وسائط التسجيل:</b> مثل الورق وUSB.</li>
                                    </ul>
                                    <h3>الثقافة الإعلامية (Media Literacy):</h3>
                                    <p>هي القدرة على تفسير المعلومات التي تم الحصول عليها من الوسائط بدقة.</p>"
                            },
                            new Lesson {
                                Title = "أخلاقيات المعلومات",
                                Content = @"
                                    <h3>أخلاقيات المعلومات:</h3>
                                    <p>هي المفاهيم والتوجهات الأساسية اللازمة للقيام بأنشطة مناسبة في مجتمع المعلومات، بغض النظر عن وجود القوانين.</p>
                                    <h3>نقاط يجب مراعاتها عند النشر:</h3>
                                    <ul>
                                        <li>يجب عدم مشاركة الصور أو مقاطع الفيديو التي يمتلكها الآخرون أو التي يحملون حقوق المؤلف الخاصة بها دون إذن.</li>
                                        <li>يجب عدم تسريب المعلومات الشخصية للآخرين.</li>
                                    </ul>
                                    <h3>المخاطر:</h3>
                                    <ul>
                                        <li><b>إدمان الإنترنت:</b> الاستخدام المفرط الذي يعطل الحياة.</li>
                                        <li><b>الجريمة الإلكترونية:</b> استخدام الكمبيوتر والشبكات في أنشطة إجرامية.</li>
                                        <li><b>انتحال الشخصية:</b> انتحال هوية شخص آخر.</li>
                                        <li><b>العلامة الجغرافية (Geotagging):</b> معلومات الموقع المضمنة في الصور تشكل خطراً للكشف عن موقعك.</li>
                                    </ul>"
                            }
                        },
                        QuizQuestions = new List<QuizQuestion>
                        {
                            new QuizQuestion { QuestionText = "ما هي الحقائق التي يتم تمثيلها باستخدام الأرقام أو الأحرف أو الرموز؟", Explanation = "البيانات هي حقائق خام يتم تمثيلها باستخدام الأرقام أو الأحرف أو الرموز.", Options = new List<QuizOption>{ new QuizOption { OptionText = "المعلومات", IsCorrect = false }, new QuizOption { OptionText = "البيانات", IsCorrect = true }, new QuizOption { OptionText = "المعرفة", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "أي خاصية للمعلومات تعني أنها لا يمكن محوها بالكامل بمجرد إنشائها؟", Explanation = "خاصية الاستمرارية (Persistence) تعني أن المعلومات لا يمكن محوها بالكامل.", Options = new List<QuizOption>{ new QuizOption { OptionText = "الانتشار", IsCorrect = false }, new QuizOption { OptionText = "الاستمرارية", IsCorrect = true }, new QuizOption { OptionText = "قابلية التكرار", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هي المعلومات التي تُحصل من طرف ثالث، مثل الكتب والصحف؟", Explanation = "المعلومات الثانوية هي التي تُحصل من طرف ثالث.", Options = new List<QuizOption>{ new QuizOption { OptionText = "معلومات أولية", IsCorrect = false }, new QuizOption { OptionText = "معلومات ثانوية", IsCorrect = true }, new QuizOption { OptionText = "معلومات أساسية", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هي القدرة على تفسير المعلومات التي تم الحصول عليها من الوسائط بدقة؟", Explanation = "الثقافة الإعلامية (Media Literacy) هي القدرة على تفسير المعلومات بدقة.", Options = new List<QuizOption>{ new QuizOption { OptionText = "أخلاقيات المعلومات", IsCorrect = false }, new QuizOption { OptionText = "الثقافة الإعلامية", IsCorrect = true }, new QuizOption { OptionText = "البيانات الوصفية", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ماذا تسمى معلومات الموقع المضمنة في الصور؟", Explanation = "العلامة الجغرافية (Geotagging) هي معلومات الموقع المضمنة في الصور.", Options = new List<QuizOption>{ new QuizOption { OptionText = "الوسائط", IsCorrect = false }, new QuizOption { OptionText = "العلامة الجغرافية", IsCorrect = true }, new QuizOption { OptionText = "المعلومات الأولية", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "أي مما يلي مثال على وسائط النقل/الإرسال؟", Explanation = "التلفزيون والإنترنت هي أمثلة على وسائط النقل.", Options = new List<QuizOption>{ new QuizOption { OptionText = "النص والصوت", IsCorrect = false }, new QuizOption { OptionText = "التلفزيون والإنترنت", IsCorrect = true }, new QuizOption { OptionText = "الورق وUSB", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هي المعلومات التي تم تحليلها وتنظيمها للمساعدة في حل المشكلات؟", Explanation = "المعرفة هي المعلومات التي تم تحليلها وتنظيمها بشكل منهجي.", Options = new List<QuizOption>{ new QuizOption { OptionText = "البيانات", IsCorrect = false }, new QuizOption { OptionText = "المعرفة", IsCorrect = true }, new QuizOption { OptionText = "الوسائط", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ماذا يتطلب التحقق من دقة وموثوقية المعلومات الثانوية؟", Explanation = "يتطلب التحقق المتبادل (Cross-checking) لتحديد دقة المعلومات الثانوية.", Options = new List<QuizOption>{ new QuizOption { OptionText = "إذن", IsCorrect = false }, new QuizOption { OptionText = "التحقق المتبادل", IsCorrect = true }, new QuizOption { OptionText = "علامة جغرافية", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "أي مما يلي يُعد من مخاطر الهواتف الذكية؟", Explanation = "إدمان الإنترنت هو أحد المشاكل المتعلقة بالهواتف الذكية.", Options = new List<QuizOption>{ new QuizOption { OptionText = "الثقافة الإعلامية", IsCorrect = false }, new QuizOption { OptionText = "إدمان الإنترنت", IsCorrect = true }, new QuizOption { OptionText = "المعلومات الأولية", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هي المفاهيم الأساسية للقيام بأنشطة مناسبة في مجتمع المعلومات؟", Explanation = "أخلاقيات المعلومات هي المفاهيم والتوجهات الأساسية اللازمة لذلك.", Options = new List<QuizOption>{ new QuizOption { OptionText = "البيانات الضخمة", IsCorrect = false }, new QuizOption { OptionText = "أخلاقيات المعلومات", IsCorrect = true }, new QuizOption { OptionText = "حقوق المؤلف", IsCorrect = false }}}
                        }
                    },
                    // Unit 2
                    new Unit
                    {
                        Title = "الوحدة الثانية: القوانين والحقوق في مجتمع المعلومات",
                        Lessons = new List<Lesson>
                        {
                            new Lesson { Title = "البيانات الشخصية", Content = @"
                                <h3>تعريفها:</h3>
                                <p>هي كل بيان أو معلومة تتعلق بشخص طبيعي محدد أو يمكن تحديده (مثل الاسم، العنوان، البيانات البيومترية). تتطلب البيانات الشخصية الحساسة (مثل العرق والديانة) عناية خاصة.</p>
                                <h3>حماية البيانات:</h3>
                                <p>ينص قانون حماية البيانات الشخصية على أنه لا يجوز جمع أو معالجة البيانات الشخصية إلا بعد موافقة صريحة من صاحب البيانات.</p>
                                <h3>الخصوصية وحق الصورة:</h3>
                                <p>الحق في الخصوصية يحمي الحياة الخاصة للفرد. حقوق الصورة تمنع استخدام مظهر الفرد دون إذنه. حقوق الدعاية تحمي المصالح الاقتصادية للمشاهير.</p>"
                            },
                            new Lesson { Title = "حقوق الملكية الفكرية", Content = @"
                                <h3>حقوق الملكية الفكرية (IPR):</h3>
                                <p>هي حقوق تحمي نتاج الإبداع الفكري.</p>
                                <h3>حقوق الملكية الصناعية:</h3>
                                <p>تحمي الابتكارات المتعلقة بالنشاط الصناعي والتجاري (مثل براءات الاختراع) وتتطلب التسجيل.</p>
                                <h3>حقوق المؤلف (Copyrights):</h3>
                                <p>تحمي الأعمال الفنية والأدبية (مثل الروايات وبرامج الكمبيوتر). مدة الحماية هي عمر المؤلف زائد 50 سنة بعد وفاته.</p>"
                            },
                             new Lesson { Title = "استخدام المعلومات والكشف عنها", Content = @"
                                <h3>الغرض من حقوق المؤلف:</h3>
                                <p>المساهمة في التطور الثقافي من خلال ضمان الاستخدام العادل (fair use) وحماية الحقوق.</p>
                                <h3>الاقتباس (Quotation):</h3>
                                <p>يسمح باستخدام جزء من عمل محمي في عملك الخاص دون إذن بشروط محددة.</p>
                                <h3>ترخيص المشاع الإبداعي (CC License):</h3>
                                <p>علامة تشير إلى شروط استخدام الأعمال المحمية (مثل الإشارة للمبدع (BY) أو عدم الاستخدام التجاري (NC)).</p>"
                            }
                        },
                        QuizQuestions = new List<QuizQuestion>
                        {
                            new QuizQuestion { QuestionText = "ما هي البيانات التي تتطلب عناية خاصة مثل العرق والديانة؟", Explanation = "البيانات الشخصية الحساسة هي التي تتطلب عناية خاصة.", Options = new List<QuizOption>{ new QuizOption { OptionText = "البيانات العامة", IsCorrect = false }, new QuizOption { OptionText = "البيانات الشخصية الحساسة", IsCorrect = true }, new QuizOption { OptionText = "البيانات الأولية", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هو المبدأ الذي يتطلبه حماية حقوق الملكية الصناعية؟", Explanation = "تتطلب حقوق الملكية الصناعية التسجيل (مبدأ الشكلية).", Options = new List<QuizOption>{ new QuizOption { OptionText = "مبدأ عدم التسجيل", IsCorrect = false }, new QuizOption { OptionText = "مبدأ الشكلية", IsCorrect = true }, new QuizOption { OptionText = "مبدأ الاستخدام العادل", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هي مدة حماية حقوق المؤلف؟", Explanation = "مدة حماية حقوق المؤلف هي عمر المؤلف زائد 50 سنة بعد وفاته.", Options = new List<QuizOption>{ new QuizOption { OptionText = "عمر المؤلف + 20 سنة", IsCorrect = false }, new QuizOption { OptionText = "عمر المؤلف + 50 سنة", IsCorrect = true }, new QuizOption { OptionText = "100 سنة", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ماذا يسمى استخدام جزء من عمل محمي في عملك الخاص دون إذن بشروط؟", Explanation = "الاقتباس (Quotation) يسمح بذلك.", Options = new List<QuizOption>{ new QuizOption { OptionText = "السرقة الأدبية", IsCorrect = false }, new QuizOption { OptionText = "الاقتباس", IsCorrect = true }, new QuizOption { OptionText = "الترخيص", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ماذا يعني رمز (NC) في ترخيص المشاع الإبداعي؟", Explanation = "رمز (NC) يعني عدم الاستخدام التجاري.", Options = new List<QuizOption>{ new QuizOption { OptionText = "الإشارة للمبدع", IsCorrect = false }, new QuizOption { OptionText = "عدم الاستخدام التجاري", IsCorrect = true }, new QuizOption { OptionText = "لا مشتقات", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هو الحق الذي يحمي الحياة الخاصة للفرد؟", Explanation = "الحق في الخصوصية هو حق دستوري يحمي الحياة الخاصة.", Options = new List<QuizOption>{ new QuizOption { OptionText = "حقوق الصورة", IsCorrect = false }, new QuizOption { OptionText = "الحق في الخصوصية", IsCorrect = true }, new QuizOption { OptionText = "حقوق الدعاية", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ماذا تضع الشركات لتوضيح كيفية حماية بيانات العملاء؟", Explanation = "تضع الشركات سياسة الخصوصية لهذا الغرض.", Options = new List<QuizOption>{ new QuizOption { OptionText = "شروط الخدمة", IsCorrect = false }, new QuizOption { OptionText = "سياسة الخصوصية", IsCorrect = true }, new QuizOption { OptionText = "اتفاقية الترخيص", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "أي نوع من حقوق الملكية الفكرية يحمي الاختراعات؟", Explanation = "حقوق الملكية الصناعية، وتحديداً براءات الاختراع، تحمي الاختراعات.", Options = new List<QuizOption>{ new QuizOption { OptionText = "حقوق المؤلف", IsCorrect = false }, new QuizOption { OptionText = "حقوق الملكية الصناعية", IsCorrect = true }, new QuizOption { OptionText = "حقوق الدعاية", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هو المبدأ الذي تتبعه حقوق المؤلف فيما يخص التسجيل؟", Explanation = "حقوق المؤلف تتبع مبدأ عدم التسجيل، حيث ينشأ الحق بمجرد إبداع العمل.", Options = new List<QuizOption>{ new QuizOption { OptionText = "مبدأ التسجيل الإجباري", IsCorrect = false }, new QuizOption { OptionText = "مبدأ عدم التسجيل", IsCorrect = true }, new QuizOption { OptionText = "مبدأ الموافقة المسبقة", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هو الغرض الرئيسي من حقوق المؤلف؟", Explanation = "الغرض هو المساهمة في التطور الثقافي من خلال ضمان الاستخدام العادل وحماية الحقوق.", Options = new List<QuizOption>{ new QuizOption { OptionText = "تحقيق الربح المادي فقط", IsCorrect = false }, new QuizOption { OptionText = "المساهمة في التطور الثقافي", IsCorrect = true }, new QuizOption { OptionText = "تقييد الإبداع", IsCorrect = false }}}
                        }
                    },
                     // Unit 3
                    new Unit
                    {
                        Title = "الوحدة الثالثة: أمن المعلومات",
                        Lessons = new List<Lesson>
                        {
                            new Lesson { Title = "عناصر وتهديدات أمن المعلومات", Content = @"<h3>العناصر الأساسية الثلاثة:</h3><ul><li>السرية (Confidentiality)</li><li>السلامة (Integrity)</li><li>التوافرية (Availability)</li></ul><h3>التهديدات:</h3><ul><li>الوصول غير المصرح به، والاختراق (Cracking).</li><li>البرمجيات الخبيثة (Malware): فيروس الكمبيوتر، حصان طروادة، الدودة، برنامج التجسس، وبرامج الفدية (Ransomware).</li><li>الجرائم الإلكترونية: التصيد (Phishing) والهندسة الاجتماعية (Social engineering).</li></ul>" },
                            new Lesson { Title = "إجراءات الأمن والمصادقة", Content = @"<h3>كلمات المرور:</h3><p>يجب أن تكون قوية (طويلة، تجمع بين الأحرف الكبيرة والصغيرة والأرقام والرموز).</p><h3>المصادقة (Authentication):</h3><p>تشمل: المصادقة القائمة على المعرفة (كلمة المرور)، المصادقة البيومترية (بصمة الإصبع)، والمصادقة القائمة على الحيازة (OTP أو SMS).</p><h3>إجراءات أخرى:</h3><ul><li>جدار الحماية (Firewall)</li><li>تحديث نظام التشغيل وبرامج مكافحة الفيروسات</li><li>إنشاء نسخ احتياطية</li></ul>" },
                            new Lesson { Title = "تقنيات السلامة", Content = @"<h3>التشفير (Encryption):</h3><p>طريقة لمنع اعتراض المعلومات. أنواع التشفير: بالمفتاح المتناظر، وبالمفتاح العام.</p><h3>التوقيع الرقمي (Digital Signature):</h3><p>تقنية تستخدم دالة التجزئة (Hash function) والتشفير بالمفتاح العام لإثبات أن البيانات من المرسل ولم يتم التلاعب بها.</p><h3>SSL/TLS:</h3><p>تقنية تستخدم لتشفير الاتصال بين متصفح الويب وخادم الويب (HTTPS).</p>" }
                        },
                        QuizQuestions = new List<QuizQuestion>
                        {
                            new QuizQuestion { QuestionText = "ما هي العناصر الأساسية الثلاثة لأمن المعلومات؟", Explanation = "العناصر هي السرية (Confidentiality)، والسلامة (Integrity)، والتوافرية (Availability).", Options = new List<QuizOption>{ new QuizOption { OptionText = "السرعة، الدقة، التكلفة", IsCorrect = false }, new QuizOption { OptionText = "السرية، السلامة، التوافرية", IsCorrect = true }, new QuizOption { OptionText = "البرمجة، الشبكات، البيانات", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هو البرنامج الخبيث الذي يشفر بياناتك ويطلب فدية؟", Explanation = "برامج الفدية (Ransomware) هي التي تقوم بذلك.", Options = new List<QuizOption>{ new QuizOption { OptionText = "فيروس", IsCorrect = false }, new QuizOption { OptionText = "برنامج الفدية", IsCorrect = true }, new QuizOption { OptionText = "حصان طروادة", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هي المصادقة التي تستخدم بصمة الإصبع؟", Explanation = "المصادقة البيومترية هي التي تستخدم الخصائص الجسدية مثل بصمة الإصبع.", Options = new List<QuizOption>{ new QuizOption { OptionText = "المصادقة بالمعرفة", IsCorrect = false }, new QuizOption { OptionText = "المصادقة البيومترية", IsCorrect = true }, new QuizOption { OptionText = "المصادقة بالحيازة", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما وظيفة جدار الحماية (Firewall)؟", Explanation = "جدار الحماية يمنع الوصول غير المصرح به من الخارج.", Options = new List<QuizOption>{ new QuizOption { OptionText = "تسريع الإنترنت", IsCorrect = false }, new QuizOption { OptionText = "منع الوصول غير المصرح به", IsCorrect = true }, new QuizOption { OptionText = "ضغط البيانات", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هو نوع التشفير الذي يستخدم نفس المفتاح للتشفير وفك التشفير؟", Explanation = "التشفير بالمفتاح المتناظر هو الذي يستخدم نفس المفتاح.", Options = new List<QuizOption>{ new QuizOption { OptionText = "التشفير بالمفتاح العام", IsCorrect = false }, new QuizOption { OptionText = "التشفير بالمفتاح المتناظر", IsCorrect = true }, new QuizOption { OptionText = "التشفير الهجين", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ماذا تسمى عملية سرقة البيانات عبر مواقع مزيفة؟", Explanation = "التصيد (Phishing) هو عملية احتيال تستخدم مواقع ويب مزيفة لسرقة المعلومات.", Options = new List<QuizOption>{ new QuizOption { OptionText = "الاختراق", IsCorrect = false }, new QuizOption { OptionText = "التصيد", IsCorrect = true }, new QuizOption { OptionText = "الهندسة الاجتماعية", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ماذا يثبت التوقيع الرقمي؟", Explanation = "التوقيع الرقمي يثبت أن البيانات من المرسل الأصلي ولم يتم التلاعب بها.", Options = new List<QuizOption>{ new QuizOption { OptionText = "سرعة الإرسال", IsCorrect = false }, new QuizOption { OptionText = "هوية المرسل وسلامة البيانات", IsCorrect = true }, new QuizOption { OptionText = "حجم البيانات", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ماذا يعني بروتوكول HTTPS؟", Explanation = "بروتوكول HTTPS يعني أن الاتصال بين المتصفح والخادم مشفر باستخدام SSL/TLS.", Options = new List<QuizOption>{ new QuizOption { OptionText = "اتصال سريع", IsCorrect = false }, new QuizOption { OptionText = "اتصال مشفر وآمن", IsCorrect = true }, new QuizOption { OptionText = "اتصال عام", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "أي برنامج خبيث يتنكر في شكل برنامج شرعي؟", Explanation = "حصان طروادة هو برنامج خبيث يتنكر في شكل برنامج شرعي.", Options = new List<QuizOption>{ new QuizOption { OptionText = "الدودة", IsCorrect = false }, new QuizOption { OptionText = "حصان طروادة", IsCorrect = true }, new QuizOption { OptionText = "برنامج التجسس", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ماذا يعني عنصر 'السلامة' (Integrity) في أمن المعلومات؟", Explanation = "السلامة تعني ضمان أن البيانات لم يتم تدميرها أو التلاعب بها.", Options = new List<QuizOption>{ new QuizOption { OptionText = "أن البيانات سرية", IsCorrect = false }, new QuizOption { OptionText = "أن البيانات لم يتم تغييرها", IsCorrect = true }, new QuizOption { OptionText = "أن البيانات متاحة", IsCorrect = false }}}
                        }
                    },
                    // Unit 4
                    new Unit
                    {
                        Title = "الوحدة الرابعة: تكنولوجيا المعلومات والمجتمع",
                        Lessons = new List<Lesson>
                        {
                            new Lesson { Title = "تطور تكنولوجيا المعلومات", Content = @"<h3>تطور المجتمع:</h3><p>مر المجتمع بمراحل: مجتمع الصيادين-الجامعين، المجتمع الزراعي، المجتمع الصناعي، وصولاً إلى مجتمع المعلومات.</p><h3>مجتمع الجيل الخامس (Society 5.0):</h3><p>يهدف إلى دمج الفضاء الافتراضي (السيبراني) والفضاء الحقيقي (المادي) لحل القضايا الاجتماعية.</p>" },
                            new Lesson { Title = "تقنيات المعلومات الجديدة", Content = @"<ul><li><b>البيانات الضخمة (Big Data):</b> مجموعات بيانات ضخمة تتميز بالحجم والتنوع والسرعة.</li><li><b>الذكاء الاصطناعي (AI):</b> تقنية تحاكي السلوك الفكري البشري.</li><li><b>إنترنت الأشياء (IoT):</b> ربط الأجهزة بالإنترنت لتمكين التواصل.</li><li><b>الواقع الافتراضي (VR)</b> و<b>الواقع المعزز (AR)</b>.</li></ul>" },
                            new Lesson { Title = "التغيرات في الحياة", Content = @"<h3>الإجهاد التكنولوجي (Technostress):</h3><p>مشاكل عقلية وجسدية تنشأ من استخدام أجهزة الكمبيوتر.</p><h3>الفجوة الرقمية (Digital Divide):</h3><p>التفاوت بين من يمكنهم الاستفادة من تكنولوجيا المعلومات ومن لا يستطيعون.</p>" }
                        },
                        QuizQuestions = new List<QuizQuestion>
                        {
                            new QuizQuestion { QuestionText = "ما هو المجتمع الذي سبق مجتمع المعلومات؟", Explanation = "المجتمع الصناعي هو الذي سبق مجتمع المعلومات.", Options = new List<QuizOption>{ new QuizOption { OptionText = "المجتمع الزراعي", IsCorrect = false }, new QuizOption { OptionText = "المجتمع الصناعي", IsCorrect = true }, new QuizOption { OptionText = "مجتمع الصيادين", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ماذا يهدف مجتمع الجيل الخامس؟", Explanation = "يهدف إلى دمج الفضاء الافتراضي والفضاء الحقيقي لحل القضايا الاجتماعية.", Options = new List<QuizOption>{ new QuizOption { OptionText = "زيادة سرعة الإنترنت", IsCorrect = false }, new QuizOption { OptionText = "دمج الفضاء الافتراضي والحقيقي", IsCorrect = true }, new QuizOption { OptionText = "العودة للماضي", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هي التقنية التي تحاكي السلوك الفكري البشري؟", Explanation = "الذكاء الاصطناعي (AI) هو الذي يحاكي السلوك الفكري البشري.", Options = new List<QuizOption>{ new QuizOption { OptionText = "البيانات الضخمة", IsCorrect = false }, new QuizOption { OptionText = "الذكاء الاصطناعي", IsCorrect = true }, new QuizOption { OptionText = "إنترنت الأشياء", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هي التقنية التي تربط الأجهزة بالإنترنت؟", Explanation = "إنترنت الأشياء (IoT) هي التي تربط الأجهزة بالإنترنت.", Options = new List<QuizOption>{ new QuizOption { OptionText = "الواقع الافتراضي", IsCorrect = false }, new QuizOption { OptionText = "إنترنت الأشياء", IsCorrect = true }, new QuizOption { OptionText = "الواقع المعزز", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ماذا تسمى المشاكل العقلية والجسدية التي تنشأ من استخدام الكمبيوتر؟", Explanation = "تسمى الإجهاد التكنولوجي (Technostress).", Options = new List<QuizOption>{ new QuizOption { OptionText = "الفجوة الرقمية", IsCorrect = false }, new QuizOption { OptionText = "الإجهاد التكنولوجي", IsCorrect = true }, new QuizOption { OptionText = "رهاب التكنولوجيا", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ماذا يسمى التفاوت بين من يملكون وصولاً للتكنولوجيا ومن لا يملكون؟", Explanation = "تسمى الفجوة الرقمية (Digital Divide).", Options = new List<QuizOption>{ new QuizOption { OptionText = "الإدمان التكنولوجي", IsCorrect = false }, new QuizOption { OptionText = "الفجوة الرقمية", IsCorrect = true }, new QuizOption { OptionText = "مجتمع المعلومات", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "أي من خصائص البيانات الضخمة التالية غير صحيح؟", Explanation = "البيانات الضخمة تتميز بالحجم والتنوع والسرعة، وليس بالبساطة.", Options = new List<QuizOption>{ new QuizOption { OptionText = "الحجم", IsCorrect = false }, new QuizOption { OptionText = "البساطة", IsCorrect = true }, new QuizOption { OptionText = "التنوع", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "مثال على تطبيق إنترنت الأشياء هو:", Explanation = "المنزل الذكي هو مثال شائع على تطبيقات إنترنت الأشياء.", Options = new List<QuizOption>{ new QuizOption { OptionText = "محرك البحث", IsCorrect = false }, new QuizOption { OptionText = "المنزل الذكي", IsCorrect = true }, new QuizOption { OptionText = "برنامج محاسبة", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هو اضطراب VDT؟", Explanation = "هو تصلب الكتف وإجهاد العين الناتج عن استخدام الكمبيوتر لفترات طويلة.", Options = new List<QuizOption>{ new QuizOption { OptionText = "الخوف من التكنولوجيا", IsCorrect = false }, new QuizOption { OptionText = "تصلب الكتف وإجهاد العين", IsCorrect = true }, new QuizOption { OptionText = "الاعتماد المفرط على الكمبيوتر", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هو الهدف الرئيسي من تحليل البيانات الضخمة؟", Explanation = "الهدف هو الكشف عن الأنماط والاتجاهات التي يمكن أن تساعد في اتخاذ قرارات أفضل.", Options = new List<QuizOption>{ new QuizOption { OptionText = "تخزين البيانات فقط", IsCorrect = false }, new QuizOption { OptionText = "الكشف عن الأنماط والاتجاهات", IsCorrect = true }, new QuizOption { OptionText = "عرض البيانات بشكل جميل", IsCorrect = false }}}
                        }
                    },
                    // Unit 5
                    new Unit
                    {
                        Title = "الوحدة الخامسة: الاتصالات",
                        Lessons = new List<Lesson>
                        {
                            new Lesson { Title = "تطور وسائل الاتصال", Content = @"<h3>التطور التاريخي:</h3><p>بدأ الاتصال بوسائل بسيطة كنيران الإشارة والطبول، ثم تطور ليشمل البريد والطباعة، وصولاً إلى الاختراعات الحديثة كالتلغراف، الهاتف، والإنترنت الذي تطور من شبكة أربانت (ARPANET).</p>" },
                            new Lesson { Title = "الاتصال وأشكاله", Content = @"<h3>حسب العدد:</h3><ul><li>واحد إلى واحد (هاتف)</li><li>واحد إلى العديد (تلفزيون)</li><li>متعدد إلى واحد (استبيانات)</li></ul><h3>حسب التزامن:</h3><ul><li>متزامن (Synchronous): في الوقت الفعلي (مكالمات الفيديو).</li><li>غير متزامن (Asynchronous): في أوقات مناسبة (البريد الإلكتروني).</li></ul>" },
                            new Lesson { Title = "الإنترنت والاتصالات", Content = @"<h3>أدوات الاتصال:</h3><p>البريد الإلكتروني (Email) يتميز بقدرة البث ويستخدم حقول To, CC, و BCC (نسخة مخفية).</p><p>منصات أخرى: نظام لوحة الإعلانات (BBS)، تطبيقات المراسلة، مكالمات الفيديو، المدونة (Blog)، ووسائل التواصل الاجتماعي.</p><h3>خصائص التواصل عبر الإنترنت:</h3><p>إخفاء الهوية، الفورية، والقابلية للتسجيل.</p>" }
                        },
                        QuizQuestions = new List<QuizQuestion>
                        {
                            new QuizQuestion { QuestionText = "ما هي الشبكة التي تطور منها الإنترنت؟", Explanation = "تطور الإنترنت من شبكة أربانت (ARPANET).", Options = new List<QuizOption>{ new QuizOption { OptionText = "شبكة الهاتف", IsCorrect = false }, new QuizOption { OptionText = "شبكة أربانت", IsCorrect = true }, new QuizOption { OptionText = "شبكة التلغراف", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "أي نوع من الاتصال يكون في الوقت الفعلي؟", Explanation = "الاتصال المتزامن (Synchronous) هو الذي يكون في الوقت الفعلي.", Options = new List<QuizOption>{ new QuizOption { OptionText = "غير متزامن", IsCorrect = false }, new QuizOption { OptionText = "متزامن", IsCorrect = true }, new QuizOption { OptionText = "متعدد", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هو الحقل الذي يستخدم لإرسال نسخة بريد إلكتروني دون علم المستلمين الآخرين؟", Explanation = "حقل BCC (نسخة مخفية) هو الذي يستخدم لهذا الغرض.", Options = new List<QuizOption>{ new QuizOption { OptionText = "To", IsCorrect = false }, new QuizOption { OptionText = "BCC", IsCorrect = true }, new QuizOption { OptionText = "CC", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "أي مما يلي مثال على اتصال 'واحد إلى العديد'؟", Explanation = "البث التلفزيوني هو مثال على اتصال 'واحد إلى العديد'.", Options = new List<QuizOption>{ new QuizOption { OptionText = "مكالمة هاتفية", IsCorrect = false }, new QuizOption { OptionText = "تلفزيون", IsCorrect = true }, new QuizOption { OptionText = "استبيان", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هي الخاصية التي تتيح حرية التعبير عبر الإنترنت ولكن قد تؤدي إلى إساءة؟", Explanation = "خاصية إخفاء الهوية هي التي تسمح بذلك.", Options = new List<QuizOption>{ new QuizOption { OptionText = "الفورية", IsCorrect = false }, new QuizOption { OptionText = "إخفاء الهوية", IsCorrect = true }, new QuizOption { OptionText = "القابلية للتسجيل", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "من اخترع الهاتف عام 1876؟", Explanation = "ألكسندر غراهام بيل هو مخترع الهاتف.", Options = new List<QuizOption>{ new QuizOption { OptionText = "مورس", IsCorrect = false }, new QuizOption { OptionText = "بيل", IsCorrect = true }, new QuizOption { OptionText = "ماركوني", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "أي نوع من الاتصال هو البريد الإلكتروني؟", Explanation = "البريد الإلكتروني هو مثال على الاتصال غير المتزامن.", Options = new List<QuizOption>{ new QuizOption { OptionText = "متزامن", IsCorrect = false }, new QuizOption { OptionText = "غير متزامن", IsCorrect = true }, new QuizOption { OptionText = "مباشر", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ماذا تسمى وسيلة إرسال المعلومات إلى عدد كبير من الناس في وقت واحد؟", Explanation = "تسمى وسائل الاتصال الجماهيري (Mass media).", Options = new List<QuizOption>{ new QuizOption { OptionText = "الاتصال الشخصي", IsCorrect = false }, new QuizOption { OptionText = "وسائل الاتصال الجماهيري", IsCorrect = true }, new QuizOption { OptionText = "الشبكات الاجتماعية", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ماذا يعني 'البث' في سياق البريد الإلكتروني؟", Explanation = "يعني القدرة على إرسال نفس الرسالة إلى عدة مستلمين في وقت واحد.", Options = new List<QuizOption>{ new QuizOption { OptionText = "حذف الرسائل", IsCorrect = false }, new QuizOption { OptionText = "إرسال رسالة لعدة أشخاص", IsCorrect = true }, new QuizOption { OptionText = "أرشفة الرسائل", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ماذا تسمى خدمة الويب التي تسمح بنشر كتابات مثل اليوميات؟", Explanation = "تسمى المدونة (Blog).", Options = new List<QuizOption>{ new QuizOption { OptionText = "البريد الإلكتروني", IsCorrect = false }, new QuizOption { OptionText = "المدونة", IsCorrect = true }, new QuizOption { OptionText = "لوحة الإعلانات", IsCorrect = false }}}
                        }
                    },
                     // Unit 6
                    new Unit
                    {
                        Title = "الوحدة السادسة: تصميم المعلومات",
                        Lessons = new List<Lesson>
                        {
                            new Lesson { Title = "التناظري والرقمي وأنظمة العد", Content = @"<h3>التناظري والرقمي:</h3><p>البيانات التناظرية مستمرة (مثل درجة الحرارة)، بينما البيانات الرقمية متقطعة (0 و 1).</p><h3>كمية البيانات:</h3><p>البت (Bit) أصغر وحدة، والبايت (Byte) هو 8 بت.</p><h3>أنظمة العد:</h3><p>النظام العشري (0-9)، النظام الثنائي (0-1)، والنظام السادس عشر (0-9 و A-F).</p><h3>ترميز الأحرف:</h3><p>ASCII للأحرف الإنجليزية، و Unicode لجميع اللغات.</p>" },
                            new Lesson { Title = "رقمنة الوسائط المتعددة", Content = @"<h3>رقمنة الصوت (PCM):</h3><p>تتم عبر: أخذ العينات (Sampling)، التحويل الكمي (Quantization)، والترميز (Encoding).</p><h3>رقمنة الصور:</h3><p>تتكون الصورة من بكسلات (Pixels). الرقمنة تتضمن: أخذ العينات (للدقة)، والتقدير الرقمي (للتدرج اللوني).</p><h3>تمثيل الألوان:</h3><p>مزج الألوان الجمعي (RGB) للطابعات، ومزج الألوان الطرحي (CMY) للشاشات.</p>" },
                            new Lesson { Title = "ضغط البيانات وتصميمها", Content = @"<h3>ضغط البيانات:</h3><p>الضغط غير الفاقد (Lossless) يستعيد البيانات كاملة. الضغط الفاقد (Lossy) لا يستعيدها كاملة.</p><h3>تصميم البيانات:</h3><p>يشمل: التجريد، التصور (Visualization)، والهيكلة (Structuring).</p><h3>واجهات المستخدم (UI):</h3><p>واجهة سطر الأوامر (CUI) وواجهة المستخدم الرسومية (GUI).</p>" }
                        },
                        QuizQuestions = new List<QuizQuestion>
                        {
                            new QuizQuestion { QuestionText = "كم عدد البتات في البايت الواحد؟", Explanation = "البايت الواحد يتكون من 8 بت.", Options = new List<QuizOption>{ new QuizOption { OptionText = "4", IsCorrect = false }, new QuizOption { OptionText = "8", IsCorrect = true }, new QuizOption { OptionText = "16", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هو نظام العد الذي يستخدم الرموز من 0 إلى 9 و A إلى F؟", Explanation = "النظام السادس عشر (Hexadecimal) هو الذي يستخدم هذه الرموز.", Options = new List<QuizOption>{ new QuizOption { OptionText = "العشري", IsCorrect = false }, new QuizOption { OptionText = "السادس عشر", IsCorrect = true }, new QuizOption { OptionText = "الثنائي", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هي الخطوة الأولى في رقمنة الصوت بطريقة PCM؟", Explanation = "الخطوة الأولى هي أخذ العينات (Sampling).", Options = new List<QuizOption>{ new QuizOption { OptionText = "الترميز", IsCorrect = false }, new QuizOption { OptionText = "أخذ العينات", IsCorrect = true }, new QuizOption { OptionText = "التحويل الكمي", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هي أصغر وحدة تشكل صورة رقمية؟", Explanation = "أصغر وحدة هي البكسل (Pixel).", Options = new List<QuizOption>{ new QuizOption { OptionText = "البايت", IsCorrect = false }, new QuizOption { OptionText = "البكسل", IsCorrect = true }, new QuizOption { OptionText = "البت", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هو نوع الضغط الذي يسمح باستعادة البيانات الأصلية بالكامل؟", Explanation = "الضغط غير الفاقد (Lossless) هو الذي يسمح بذلك.", Options = new List<QuizOption>{ new QuizOption { OptionText = "الضغط الفاقد", IsCorrect = false }, new QuizOption { OptionText = "الضغط غير الفاقد", IsCorrect = true }, new QuizOption { OptionText = "الضغط العالي", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "أي نظام ترميز يهدف إلى شمل جميع لغات العالم؟", Explanation = "يونيكود (Unicode) هو المعيار الذي يهدف إلى ذلك.", Options = new List<QuizOption>{ new QuizOption { OptionText = "ASCII", IsCorrect = false }, new QuizOption { OptionText = "Unicode", IsCorrect = true }, new QuizOption { OptionText = "EBCDIC", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هو نموذج الألوان المستخدم في الشاشات؟", Explanation = "نموذج RGB (أحمر، أخضر، أزرق) هو المستخدم في الشاشات.", Options = new List<QuizOption>{ new QuizOption { OptionText = "CMYK", IsCorrect = false }, new QuizOption { OptionText = "RGB", IsCorrect = true }, new QuizOption { OptionText = "Grayscale", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ماذا تسمى عملية تنظيم البيانات بصرياً كالرسوم البيانية؟", Explanation = "تسمى التصور (Visualization).", Options = new List<QuizOption>{ new QuizOption { OptionText = "التجريد", IsCorrect = false }, new QuizOption { OptionText = "التصور", IsCorrect = true }, new QuizOption { OptionText = "الهيكلة", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "أي واجهة مستخدم تعتمد على إدخال الأوامر النصية؟", Explanation = "واجهة سطر الأوامر (CUI) هي التي تعتمد على ذلك.", Options = new List<QuizOption>{ new QuizOption { OptionText = "GUI", IsCorrect = false }, new QuizOption { OptionText = "CUI", IsCorrect = true }, new QuizOption { OptionText = "VUI", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هي البيانات التي تتغير بشكل مستمر؟", Explanation = "البيانات التناظرية هي التي تتغير بشكل مستمر.", Options = new List<QuizOption>{ new QuizOption { OptionText = "الرقمية", IsCorrect = false }, new QuizOption { OptionText = "التناظرية", IsCorrect = true }, new QuizOption { OptionText = "الثنائية", IsCorrect = false }}}
                        }
                    },
                    // Unit 7
                    new Unit
                    {
                        Title = "الوحدة السابعة: الكمبيوترات",
                        Lessons = new List<Lesson>
                        {
                            new Lesson { Title = "بنية الكمبيوتر", Content = @"<h3>المكونات الخمسة الرئيسية:</h3><ul><li>جهاز الإدخال (لوحة المفاتيح)</li><li>وحدة التحكم</li><li>وحدة الحساب والمنطق</li><li>الذاكرة الرئيسية</li><li>جهاز الإخراج (الشاشة)</li></ul><h3>وحدة المعالجة المركزية (CPU):</h3><p>تشمل وحدة التحكم ووحدة الحساب والمنطق.</p><h3>الذاكرة:</h3><p>الذاكرة الرئيسية (مؤقتة) وذاكرة التخزين الثانوية (طويلة الأجل).</p><h3>الواجهات (Interface):</h3><p>مثل USB, HDMI, Ethernet.</p>" },
                            new Lesson { Title = "برامج الكمبيوتر", Content = @"<h3>العتاد (Hardware) والبرمجيات (Software):</h3><p>العتاد هو الأجزاء المادية، والبرمجيات هي البرامج التي تعمل عليه.</p><h3>أنواع البرمجيات:</h3><ul><li>برمجيات النظام (System Software): مثل نظام التشغيل (OS).</li><li>برنامج التطبيق (Application Software): لأداء مهام محددة.</li></ul>" },
                            new Lesson { Title = "الدوائر المنطقية", Content = @"<h3>البوابات الأساسية:</h3><ul><li>بوابة AND: تُخرج 1 فقط عندما تكون جميع المدخلات 1.</li><li>بوابة OR: تُخرج 1 إذا كان مدخل واحد على الأقل 1.</li><li>بوابة NOT: تُخرج النتيجة المعاكسة للمدخل.</li></ul>" }
                        },
                         QuizQuestions = new List<QuizQuestion>
                        {
                            new QuizQuestion { QuestionText = "ما هي المكونات التي تشكل وحدة المعالجة المركزية (CPU)؟", Explanation = "تتكون وحدة المعالجة المركزية من وحدة التحكم ووحدة الحساب والمنطق.", Options = new List<QuizOption>{ new QuizOption { OptionText = "الذاكرة والشاشة", IsCorrect = false }, new QuizOption { OptionText = "وحدة التحكم ووحدة الحساب والمنطق", IsCorrect = true }, new QuizOption { OptionText = "لوحة المفاتيح والطابعة", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "أي نوع من الذاكرة يستخدم للتخزين طويل الأجل؟", Explanation = "ذاكرة التخزين الثانوية (مثل SSD أو USB) تستخدم للتخزين طويل الأجل.", Options = new List<QuizOption>{ new QuizOption { OptionText = "الذاكرة الرئيسية (RAM)", IsCorrect = false }, new QuizOption { OptionText = "ذاكرة التخزين الثانوية", IsCorrect = true }, new QuizOption { OptionText = "ذاكرة الكاش", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "أي بوابة منطقية تُخرج 1 فقط إذا كانت جميع المدخلات 1؟", Explanation = "بوابة AND هي التي تفعل ذلك.", Options = new List<QuizOption>{ new QuizOption { OptionText = "OR", IsCorrect = false }, new QuizOption { OptionText = "AND", IsCorrect = true }, new QuizOption { OptionText = "NOT", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "أي بوابة منطقية تعكس قيمة المدخل؟", Explanation = "بوابة NOT هي التي تعكس قيمة المدخل.", Options = new List<QuizOption>{ new QuizOption { OptionText = "AND", IsCorrect = false }, new QuizOption { OptionText = "NOT", IsCorrect = true }, new QuizOption { OptionText = "OR", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هو نظام التشغيل (OS)؟", Explanation = "نظام التشغيل هو نوع من برمجيات النظام.", Options = new List<QuizOption>{ new QuizOption { OptionText = "برنامج تطبيق", IsCorrect = false }, new QuizOption { OptionText = "برمجيات النظام", IsCorrect = true }, new QuizOption { OptionText = "عتاد", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "أي واجهة تستخدم لنقل الفيديو والصوت معًا؟", Explanation = "واجهة HDMI هي المستخدمة لهذا الغرض.", Options = new List<QuizOption>{ new QuizOption { OptionText = "USB", IsCorrect = false }, new QuizOption { OptionText = "HDMI", IsCorrect = true }, new QuizOption { OptionText = "Ethernet", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ماذا تسمى الأجهزة المادية للكمبيوتر؟", Explanation = "تسمى العتاد (Hardware).", Options = new List<QuizOption>{ new QuizOption { OptionText = "البرمجيات", IsCorrect = false }, new QuizOption { OptionText = "العتاد", IsCorrect = true }, new QuizOption { OptionText = "البيانات", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هي وظيفة وحدة الحساب والمنطق (ALU)؟", Explanation = "وظيفتها هي أداء العمليات الحسابية والمنطقية.", Options = new List<QuizOption>{ new QuizOption { OptionText = "تخزين البيانات", IsCorrect = false }, new QuizOption { OptionText = "أداء الحسابات", IsCorrect = true }, new QuizOption { OptionText = "التحكم في الأجهزة", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "أي مما يلي مثال على جهاز إدخال؟", Explanation = "لوحة المفاتيح هي مثال كلاسيكي على جهاز الإدخال.", Options = new List<QuizOption>{ new QuizOption { OptionText = "الشاشة", IsCorrect = false }, new QuizOption { OptionText = "لوحة المفاتيح", IsCorrect = true }, new QuizOption { OptionText = "الطابعة", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "أي مما يلي مثال على برنامج تطبيق؟", Explanation = "برامج معالجة النصوص هي من أشهر برامج التطبيقات.", Options = new List<QuizOption>{ new QuizOption { OptionText = "نظام التشغيل", IsCorrect = false }, new QuizOption { OptionText = "معالج النصوص", IsCorrect = true }, new QuizOption { OptionText = "برنامج تشغيل الجهاز", IsCorrect = false }}}
                        }
                    },
                    // Unit 8
                    new Unit
                    {
                        Title = "الوحدة الثامنة: الشبكات",
                        Lessons = new List<Lesson>
                        {
                            new Lesson { Title = "شبكات الكمبيوتر وأنماط الاستخدام", Content = @"<h3>الشبكات:</h3><p>شبكة المنطقة المحلية (LAN) وشبكة المنطقة الواسعة (WAN). الإنترنت يربط بينهما عالمياً.</p><h3>مكونات:</h3><p>جهاز التوجيه (Router)، المحول (Hub)، وموفر خدمة الإنترنت (ISP).</p><h3>أنماط الاستخدام:</h3><p>نظام العميل-الخادم (Client-Server) ونظام الند إلى ند (Peer-to-Peer).</p><h3>طرق الاتصال:</h3><p>تبديل الدوائر وتبديل الحزم (Packets).</p>" },
                            new Lesson { Title = "العنونة والبروتوكولات", Content = @"<h3>عنوان IP:</h3><p>رقم تعريفي فريد لكل جهاز (IPv4 و IPv6).</p><h3>اسم النطاق (Domain Name):</h3><p>سلسلة أحرف تسهل فهم عنوان IP. DNS يربط بينهما.</p><h3>بروتوكول الاتصال:</h3><p>TCP (يضمن الموثوقية)، UDP (يركز على السرعة)، وIP (يعين العناوين).</p>" },
                            new Lesson { Title = "آلية عمل الويب والبريد الإلكتروني", Content = @"<h3>الويب (WWW):</h3><p>تبنى صفحاته بلغة HTML وتُحدد مواقعها بـ URL.</p><h3>البريد الإلكتروني:</h3><p>يستخدم بروتوكول SMTP للإرسال، و POP أو IMAP للاستقبال.</p><h3>سرعة النقل:</h3><p>تُقاس بوحدة bps (بت في الثانية).</p>" }
                        },
                        QuizQuestions = new List<QuizQuestion>
                        {
                            new QuizQuestion { QuestionText = "ما هو الجهاز الذي يرحل ويعيد توجيه البيانات بين الشبكات المختلفة؟", Explanation = "جهاز التوجيه (Router) هو الذي يقوم بذلك.", Options = new List<QuizOption>{ new QuizOption { OptionText = "المحول (Hub)", IsCorrect = false }, new QuizOption { OptionText = "جهاز التوجيه (Router)", IsCorrect = true }, new QuizOption { OptionText = "الخادم (Server)", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هو نظام العنونة الذي يحل مشكلة نفاد عناوين IPv4؟", Explanation = "نظام IPv6 هو الذي تم تطويره لهذا الغرض.", Options = new List<QuizOption>{ new QuizOption { OptionText = "DNS", IsCorrect = false }, new QuizOption { OptionText = "IPv6", IsCorrect = true }, new QuizOption { OptionText = "TCP", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هو البروتوكول الذي يضمن موثوقية توصيل الحزم وترتيبها؟", Explanation = "بروتوكول TCP هو المسؤول عن ذلك.", Options = new List<QuizOption>{ new QuizOption { OptionText = "UDP", IsCorrect = false }, new QuizOption { OptionText = "TCP", IsCorrect = true }, new QuizOption { OptionText = "IP", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هي اللغة المستخدمة لإنشاء صفحات الويب؟", Explanation = "لغة HTML هي المستخدمة لإنشاء صفحات الويب.", Options = new List<QuizOption>{ new QuizOption { OptionText = "SQL", IsCorrect = false }, new QuizOption { OptionText = "HTML", IsCorrect = true }, new QuizOption { OptionText = "Python", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هو البروتوكول المستخدم لإرسال البريد الإلكتروني؟", Explanation = "بروتوكول SMTP هو المستخدم لإرسال البريد.", Options = new List<QuizOption>{ new QuizOption { OptionText = "POP", IsCorrect = false }, new QuizOption { OptionText = "SMTP", IsCorrect = true }, new QuizOption { OptionText = "IMAP", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ماذا تسمى طريقة الاتصال التي تقسم البيانات إلى حزم؟", Explanation = "تسمى طريقة تبديل الحزم (Packet switching).", Options = new List<QuizOption>{ new QuizOption { OptionText = "تبديل الدوائر", IsCorrect = false }, new QuizOption { OptionText = "تبديل الحزم", IsCorrect = true }, new QuizOption { OptionText = "الوصول المباشر", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما وظيفة DNS؟", Explanation = "يقوم DNS بربط أسماء النطاقات بعناوين IP.", Options = new List<QuizOption>{ new QuizOption { OptionText = "تشفير البيانات", IsCorrect = false }, new QuizOption { OptionText = "ربط اسم النطاق بعنوان IP", IsCorrect = true }, new QuizOption { OptionText = "توجيه الحزم", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "أي بروتوكول يركز على السرعة في الوقت الفعلي للمكالمات والبث؟", Explanation = "بروتوكول UDP هو الذي يركز على السرعة.", Options = new List<QuizOption>{ new QuizOption { OptionText = "TCP", IsCorrect = false }, new QuizOption { OptionText = "UDP", IsCorrect = true }, new QuizOption { OptionText = "HTTP", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ماذا تسمى الشبكة التي تغطي منطقة محدودة مثل منزل أو مكتب؟", Explanation = "تسمى شبكة المنطقة المحلية (LAN).", Options = new List<QuizOption>{ new QuizOption { OptionText = "WAN", IsCorrect = false }, new QuizOption { OptionText = "LAN", IsCorrect = true }, new QuizOption { OptionText = "MAN", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هي الوحدة التي تقاس بها سرعة نقل البيانات؟", Explanation = "تقاس بوحدة bps (بت في الثانية).", Options = new List<QuizOption>{ new QuizOption { OptionText = "Bytes", IsCorrect = false }, new QuizOption { OptionText = "bps", IsCorrect = true }, new QuizOption { OptionText = "Hertz", IsCorrect = false }}}
                        }
                    },
                     // Unit 9
                    new Unit
                    {
                        Title = "الوحدة التاسعة: قواعد البيانات",
                        Lessons = new List<Lesson>
                        {
                            new Lesson { Title = "مقدمة في قواعد البيانات", Content = @"<h3>قاعدة البيانات (Database):</h3><p>مجموعة منظمة من البيانات.</p><h3>نظام إدارة قواعد البيانات (DBMS):</h3><p>نظام يدير قواعد البيانات ويوفر وظائف مثل تناسق وتكامل البيانات.</p>" },
                            new Lesson { Title = "أنواع قواعد البيانات", Content = @"<p>تشمل: الهرمية، الشبكية، والعالائقية (RDB).</p><h3>قواعد البيانات العالئقية (RDB):</h3><p>تُنظم البيانات في جداول (صفوف/سجلات وأعمدة/حقول). SQL هي اللغة المستخدمة لمعالجتها. عملياتها تشمل: الانتقاء (Selection)، العرض (Projection)، والربط (Join).</p>" },
                            new Lesson { Title = "نظم المعلومات المختلفة", Content = @"<ul><li>TPS: يعالج المعاملات اليومية.</li><li>MIS: يوفر تقارير دورية.</li><li>DSS: يدعم القرارات غير الروتينية.</li><li>EIS: يوفر معلومات موجزة للمستوى التنفيذي.</li><li>ERP: نظام متكامل يجمع وظائف الأعمال.</li></ul>" }
                        },
                        QuizQuestions = new List<QuizQuestion>
                        {
                            new QuizQuestion { QuestionText = "ما هو البرنامج الذي يدير قواعد البيانات؟", Explanation = "نظام إدارة قواعد البيانات (DBMS) هو الذي يديرها.", Options = new List<QuizOption>{ new QuizOption { OptionText = "نظام التشغيل", IsCorrect = false }, new QuizOption { OptionText = "DBMS", IsCorrect = true }, new QuizOption { OptionText = "المتصفح", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هو النوع الأكثر شيوعًا من قواعد البيانات؟", Explanation = "قاعدة البيانات العالئقية (RDB) هي الأكثر شيوعًا.", Options = new List<QuizOption>{ new QuizOption { OptionText = "الهرمية", IsCorrect = false }, new QuizOption { OptionText = "العالئقية", IsCorrect = true }, new QuizOption { OptionText = "الشبكية", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هي اللغة المستخدمة لمعالجة البيانات في RDB؟", Explanation = "لغة SQL هي المستخدمة لهذا الغرض.", Options = new List<QuizOption>{ new QuizOption { OptionText = "HTML", IsCorrect = false }, new QuizOption { OptionText = "SQL", IsCorrect = true }, new QuizOption { OptionText = "Python", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ماذا تسمى عملية استخراج صفوف بشروط معينة من جدول؟", Explanation = "تسمى عملية الانتقاء (Selection).", Options = new List<QuizOption>{ new QuizOption { OptionText = "العرض", IsCorrect = false }, new QuizOption { OptionText = "الانتقاء", IsCorrect = true }, new QuizOption { OptionText = "الربط", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هو النظام الذي يسجل ويعالج المعاملات اليومية؟", Explanation = "نظام معالجة المعاملات (TPS) هو الذي يقوم بذلك.", Options = new List<QuizOption>{ new QuizOption { OptionText = "MIS", IsCorrect = false }, new QuizOption { OptionText = "TPS", IsCorrect = true }, new QuizOption { OptionText = "DSS", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ماذا تسمى الصفوف في قاعدة البيانات العالئقية؟", Explanation = "تسمى الصفوف 'سجلات'.", Options = new List<QuizOption>{ new QuizOption { OptionText = "حقول", IsCorrect = false }, new QuizOption { OptionText = "سجلات", IsCorrect = true }, new QuizOption { OptionText = "جداول", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ماذا تسمى الأعمدة في قاعدة البيانات العالئقية؟", Explanation = "تسمى الأعمدة 'حقول'.", Options = new List<QuizOption>{ new QuizOption { OptionText = "سجلات", IsCorrect = false }, new QuizOption { OptionText = "حقول", IsCorrect = true }, new QuizOption { OptionText = "علاقات", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هي العملية التي تربط بين جداول متعددة؟", Explanation = "عملية الربط (Join) هي التي تقوم بذلك.", Options = new List<QuizOption>{ new QuizOption { OptionText = "الانتقاء", IsCorrect = false }, new QuizOption { OptionText = "الربط", IsCorrect = true }, new QuizOption { OptionText = "العرض", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هو النظام المتكامل الذي يجمع وظائف الأعمال المختلفة؟", Explanation = "نظام تخطيط موارد المؤسسة (ERP) هو الذي يقوم بذلك.", Options = new List<QuizOption>{ new QuizOption { OptionText = "DSS", IsCorrect = false }, new QuizOption { OptionText = "ERP", IsCorrect = true }, new QuizOption { OptionText = "EIS", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هي وظيفة DBMS التي تضمن استعادة البيانات بعد الأعطال؟", Explanation = "وظيفة التوافر (Availability) هي المسؤولة عن ذلك.", Options = new List<QuizOption>{ new QuizOption { OptionText = "السرية", IsCorrect = false }, new QuizOption { OptionText = "التوافر", IsCorrect = true }, new QuizOption { OptionText = "التكامل", IsCorrect = false }}}
                        }
                    },
                    // Unit 10
                    new Unit
                    {
                        Title = "الوحدة العاشرة: تحليل البيانات",
                        Lessons = new List<Lesson>
                        {
                            new Lesson { Title = "أنواع البيانات والتحليل", Content = @"<h3>البيانات النوعية:</h3><p>الاسمية (بدون ترتيب) والترتيبية (مع ترتيب).</p><h3>البيانات الكمية:</h3><p>الفاصلة (بدون صفر مطلق) والنسبية (مع صفر مطلق).</p><h3>طرق التحليل:</h3><p>الإحصاء الوصفي والإحصاء الاستدلالي.</p>" },
                            new Lesson { Title = "الإحصاء الوصفي", Content = @"<h3>مقاييس النزعة المركزية:</h3><p>المتوسط (Mean)، الوسيط (Median)، المنوال (Mode).</p><h3>مقاييس التشتت:</h3><p>التباين (Variance)، والانحراف المعياري (Standard Deviation).</p><h3>الرباعيات ومخطط الصندوق:</h3><p>الرباعيات (Quartile) تقسم البيانات، ومخطط الصندوق والشارب يمثلها بصرياً.</p>" },
                            new Lesson { Title = "العلاقات والتنبؤ", Content = @"<h3>المخطط المبعثر والارتباط:</h3><p>المخطط المبعثر (Scatter Plot) يمثل العلاقة بين متغيرين. الارتباط قد يكون إيجابي، سلبي، أو لا يوجد.</p><h3>تحليل الانحدار:</h3><p>يستخدم للتنبؤ بقيمة متغير بناءً على آخر، ويحدد خط الانحدار.</p>" }
                        },
                        QuizQuestions = new List<QuizQuestion>
                        {
                            new QuizQuestion { QuestionText = "أي نوع من البيانات له ترتيب ولكن لا يمكن قياس المسافة بين قيمه؟", Explanation = "البيانات الترتيبية لها ترتيب ولكن المسافات غير ذات معنى.", Options = new List<QuizOption>{ new QuizOption { OptionText = "الاسمية", IsCorrect = false }, new QuizOption { OptionText = "الترتيبية", IsCorrect = true }, new QuizOption { OptionText = "الفاصلة", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هو مقياس النزعة المركزية الذي يمثل القيمة الأكثر تكراراً؟", Explanation = "المنوال (Mode) هو القيمة الأكثر تكراراً.", Options = new List<QuizOption>{ new QuizOption { OptionText = "المتوسط", IsCorrect = false }, new QuizOption { OptionText = "المنوال", IsCorrect = true }, new QuizOption { OptionText = "الوسيط", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ماذا يقيس الانحراف المعياري؟", Explanation = "يقيس الانحراف المعياري مدى تشتت البيانات حول المتوسط.", Options = new List<QuizOption>{ new QuizOption { OptionText = "القيمة المركزية", IsCorrect = false }, new QuizOption { OptionText = "تشتت البيانات", IsCorrect = true }, new QuizOption { OptionText = "العلاقة بين متغيرين", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ماذا يعني الارتباط الإيجابي بين متغيرين؟", Explanation = "يعني أنهما يتزايدان معاً.", Options = new List<QuizOption>{ new QuizOption { OptionText = "أحدهما يزيد والآخر ينقص", IsCorrect = false }, new QuizOption { OptionText = "يتزايدان معاً", IsCorrect = true }, new QuizOption { OptionText = "لا توجد علاقة", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هو الغرض من تحليل الانحدار؟", Explanation = "يستخدم تحليل الانحدار للتنبؤ بقيمة متغير بناءً على آخر.", Options = new List<QuizOption>{ new QuizOption { OptionText = "وصف البيانات فقط", IsCorrect = false }, new QuizOption { OptionText = "التنبؤ", IsCorrect = true }, new QuizOption { OptionText = "إيجاد المنوال", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هو الوسيط (Median)؟", Explanation = "الوسيط هو القيمة المركزية في البيانات المرتبة.", Options = new List<QuizOption>{ new QuizOption { OptionText = "متوسط القيم", IsCorrect = false }, new QuizOption { OptionText = "القيمة المركزية", IsCorrect = true }, new QuizOption { OptionText = "القيمة الأكثر شيوعًا", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "أي رسم بياني يستخدم لإظهار العلاقة بين متغيرين؟", Explanation = "المخطط المبعثر (Scatter Plot) يستخدم لهذا الغرض.", Options = new List<QuizOption>{ new QuizOption { OptionText = "المدرج التكراري", IsCorrect = false }, new QuizOption { OptionText = "المخطط المبعثر", IsCorrect = true }, new QuizOption { OptionText = "مخطط الصندوق", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هو الجذر التربيعي للتباين؟", Explanation = "الانحراف المعياري هو الجذر التربيعي للتباين.", Options = new List<QuizOption>{ new QuizOption { OptionText = "المدى", IsCorrect = false }, new QuizOption { OptionText = "الانحراف المعياري", IsCorrect = true }, new QuizOption { OptionText = "المتوسط", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هي الدالة المستخدمة لحساب المتوسط في جداول البيانات؟", Explanation = "دالة AVERAGE() هي المستخدمة لحساب المتوسط.", Options = new List<QuizOption>{ new QuizOption { OptionText = "MEDIAN()", IsCorrect = false }, new QuizOption { OptionText = "AVERAGE()", IsCorrect = true }, new QuizOption { OptionText = "MODE()", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ماذا يمثل الرباعي الثاني (Q2)؟", Explanation = "الرباعي الثاني هو نفسه الوسيط (Median).", Options = new List<QuizOption>{ new QuizOption { OptionText = "المتوسط", IsCorrect = false }, new QuizOption { OptionText = "الوسيط", IsCorrect = true }, new QuizOption { OptionText = "المنوال", IsCorrect = false }}}
                        }
                    },
                    // Unit 11
                    new Unit
                    {
                        Title = "الوحدة الحادية عشر: المحاكاة",
                        Lessons = new List<Lesson>
                        {
                            new Lesson { Title = "النمذجة (Modeling)", Content = @"<h3>النموذج (Model):</h3><p>تمثيل مبسط لظاهرة مستهدفة.</p><h3>تصنيف النماذج:</h3><ul><li><b>حسب الخصائص:</b> ثابت، ديناميكي (حتمي أو احتمالي).</li><li><b>حسب التعبير:</b> مادي، تخطيطي، رياضي.</li></ul>" },
                            new Lesson { Title = "المحاكاة (Simulation)", Content = @"<h3>المحاكاة:</h3><p>التلاعب بالنموذج للتنبؤ بظواهر أو أحداث.</p><h3>المراجع في جداول البيانات:</h3><p>المرجع النسبي (يتغير) والمرجع المطلق (ثابت، يستخدم '$').</p><h3>طريقة مونت كارلو:</h3><p>طريقة لحل المشكلات باستخدام الأرقام العشوائية.</p>" },
                            new Lesson { Title = "قوائم الانتظار (Queues)", Content = @"<p>نظام يتم فيه تحديد وقت الانتظار بناءً على ترتيب الوصول ومدة الخدمة. يُطبق على العمليات الحاسوبية وطوابير الخدمة.</p>" }
                        },
                        QuizQuestions = new List<QuizQuestion>
                        {
                            new QuizQuestion { QuestionText = "ما هو التمثيل المبسط لظاهرة مستهدفة؟", Explanation = "النموذج (Model) هو تمثيل مبسط لظاهرة مستهدفة.", Options = new List<QuizOption>{ new QuizOption { OptionText = "المحاكاة", IsCorrect = false }, new QuizOption { OptionText = "النموذج", IsCorrect = true }, new QuizOption { OptionText = "الخوارزمية", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "أي نوع من النماذج يتضمن سلوكًا غير منتظم؟", Explanation = "النموذج الاحتمالي هو الذي يتضمن سلوكًا غير منتظم.", Options = new List<QuizOption>{ new QuizOption { OptionText = "الحتمي", IsCorrect = false }, new QuizOption { OptionText = "الاحتمالي", IsCorrect = true }, new QuizOption { OptionText = "الثابت", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "أي نوع من النماذج يمثل شيئًا ما باستخدام معادلات رياضية؟", Explanation = "النموذج الرياضي هو الذي يستخدم المعادلات.", Options = new List<QuizOption>{ new QuizOption { OptionText = "المادي", IsCorrect = false }, new QuizOption { OptionText = "الرياضي", IsCorrect = true }, new QuizOption { OptionText = "التخطيطي", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ماذا تسمى عملية التلاعب بالنموذج للتنبؤ بالظواهر؟", Explanation = "تسمى المحاكاة (Simulation).", Options = new List<QuizOption>{ new QuizOption { OptionText = "النمذجة", IsCorrect = false }, new QuizOption { OptionText = "المحاكاة", IsCorrect = true }, new QuizOption { OptionText = "التحليل", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هو الرمز المستخدم للمرجع المطلق في جداول البيانات؟", Explanation = "يستخدم الرمز '$' للمرجع المطلق.", Options = new List<QuizOption>{ new QuizOption { OptionText = "#", IsCorrect = false }, new QuizOption { OptionText = "$", IsCorrect = true }, new QuizOption { OptionText = "@", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هي الطريقة التي تستخدم الأرقام العشوائية لحل المشكلات؟", Explanation = "طريقة مونت كارلو هي التي تستخدم الأرقام العشوائية.", Options = new List<QuizOption>{ new QuizOption { OptionText = "طريقة المربعات الصغرى", IsCorrect = false }, new QuizOption { OptionText = "طريقة مونت كارلو", IsCorrect = true }, new QuizOption { OptionText = "طريقة نيوتن", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هي دالة جداول البيانات التي تولد أرقامًا عشوائية بين 0 و 1؟", Explanation = "دالة RAND() هي التي تقوم بذلك.", Options = new List<QuizOption>{ new QuizOption { OptionText = "SUM()", IsCorrect = false }, new QuizOption { OptionText = "RAND()", IsCorrect = true }, new QuizOption { OptionText = "IF()", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "على ماذا يعتمد تحديد وقت الانتظار في قوائم الانتظار؟", Explanation = "يعتمد على ترتيب الوصول ومدة الخدمة.", Options = new List<QuizOption>{ new QuizOption { OptionText = "الأولوية فقط", IsCorrect = false }, new QuizOption { OptionText = "ترتيب الوصول ومدة الخدمة", IsCorrect = true }, new QuizOption { OptionText = "الوقت العشوائي", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "أي نوع من النماذج لا يتغير بمرور الوقت؟", Explanation = "النموذج الثابت هو الذي لا يتغير بمرور الوقت.", Options = new List<QuizOption>{ new QuizOption { OptionText = "الديناميكي", IsCorrect = false }, new QuizOption { OptionText = "الثابت", IsCorrect = true }, new QuizOption { OptionText = "الاحتمالي", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هو مثال على النموذج المادي؟", Explanation = "نموذج الحمض النووي هو مثال على النموذج المادي.", Options = new List<QuizOption>{ new QuizOption { OptionText = "مخطط تدفق", IsCorrect = false }, new QuizOption { OptionText = "نموذج الحمض النووي", IsCorrect = true }, new QuizOption { OptionText = "معادلة رياضية", IsCorrect = false }}}
                        }
                    },
                    // Unit 12
                    new Unit
                    {
                        Title = "الوحدة الثانية عشرة: البرمجة",
                        Lessons = new List<Lesson>
                        {
                            new Lesson { Title = "الخوارزميات ولغات البرمجة", Content = @"<h3>الخوارزمية (Algorithm):</h3><p>طريقة أو إجراء لحل مشكلة معينة.</p><h3>التمثيل المرئي:</h3><p>المخطط الانسيابي (Flowchart) ومخطط النشاط (Activity Diagram).</p><h3>لغة البرمجة:</h3><p>لغة للتعبير عن الخوارزميات (مثل Python, JavaScript, Scratch).</p>" },
                            new Lesson { Title = "هياكل التحكم", Content = @"<h3>المتغيرات (Variables):</h3><p>تستخدم لتخزين البيانات.</p><h3>هياكل التحكم الأساسية:</h3><ul><li>البنية التسلسلية (Sequential)</li><li>البنية التكرارية (Loop) باستخدام 'for'</li><li>البنية التفريعية (Branching) باستخدام 'if, else'</li></ul>" },
                            new Lesson { Title = "الدوال وهياكل البيانات", Content = @"<h3>الدالة (Function):</h3><p>مجموعة من العمليات الموحدة تستقبل وسيطات (Arguments) وتُرجع قيمة (Return Value).</p><h3>القوائم (Lists/Arrays):</h3><p>هياكل بيانات لتخزين مجموعة من العناصر بترتيب.</p>" }
                        },
                        QuizQuestions = new List<QuizQuestion>
                        {
                            new QuizQuestion { QuestionText = "ما هي الطريقة أو الإجراء لحل مشكلة معينة؟", Explanation = "الخوارزمية (Algorithm) هي طريقة أو إجراء لحل مشكلة.", Options = new List<QuizOption>{ new QuizOption { OptionText = "لغة البرمجة", IsCorrect = false }, new QuizOption { OptionText = "الخوارزمية", IsCorrect = true }, new QuizOption { OptionText = "الدالة", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "أي تمثيل مرئي مناسب لتمثيل تدفقات العمليات المتوازية؟", Explanation = "مخطط النشاط (Activity Diagram) هو المناسب لذلك.", Options = new List<QuizOption>{ new QuizOption { OptionText = "المخطط الانسيابي", IsCorrect = false }, new QuizOption { OptionText = "مخطط النشاط", IsCorrect = true }, new QuizOption { OptionText = "مخطط الصندوق", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هي اللغة المستخدمة بشكل شائع في الذكاء الاصطناعي والإحصاء؟", Explanation = "لغة Python هي المستخدمة بشكل شائع في هذه المجالات.", Options = new List<QuizOption>{ new QuizOption { OptionText = "JavaScript", IsCorrect = false }, new QuizOption { OptionText = "Python", IsCorrect = true }, new QuizOption { OptionText = "Scratch", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هو الرمز المستخدم لتعيين قيمة لمتغير؟", Explanation = "يُستخدم معامل التخصيص (=) لتعيين قيمة للمتغير.", Options = new List<QuizOption>{ new QuizOption { OptionText = "==", IsCorrect = false }, new QuizOption { OptionText = "=", IsCorrect = true }, new QuizOption { OptionText = "!=", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "أي بنية تحكم تستخدم لتكرار عملية؟", Explanation = "البنية التكرارية (Loop) هي التي تستخدم للتكرار.", Options = new List<QuizOption>{ new QuizOption { OptionText = "التسلسلية", IsCorrect = false }, new QuizOption { OptionText = "التكرارية", IsCorrect = true }, new QuizOption { OptionText = "التفريعية", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هي الكلمة المفتاحية المستخدمة لإرجاع قيمة من دالة؟", Explanation = "تُستخدم كلمة 'return' لإرجاع قيمة.", Options = new List<QuizOption>{ new QuizOption { OptionText = "def", IsCorrect = false }, new QuizOption { OptionText = "return", IsCorrect = true }, new QuizOption { OptionText = "if", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ما هي هياكل البيانات المستخدمة لتخزين مجموعة من العناصر بترتيب؟", Explanation = "القوائم (Lists/Arrays) هي المستخدمة لهذا الغرض.", Options = new List<QuizOption>{ new QuizOption { OptionText = "المتغيرات", IsCorrect = false }, new QuizOption { OptionText = "القوائم", IsCorrect = true }, new QuizOption { OptionText = "الدوال", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "أي بنية تحكم تستخدم لفصل العمليات حسب الشروط؟", Explanation = "البنية التفريعية (Branching) هي التي تستخدم لذلك.", Options = new List<QuizOption>{ new QuizOption { OptionText = "التكرارية", IsCorrect = false }, new QuizOption { OptionText = "البنية التفريعية", IsCorrect = true }, new QuizOption { OptionText = "التسلسلية", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "ماذا تسمى القيم التي تستقبلها الدالة؟", Explanation = "تسمى الوسيطات (Arguments).", Options = new List<QuizOption>{ new QuizOption { OptionText = "قيم الإرجاع", IsCorrect = false }, new QuizOption { OptionText = "الوسيطات", IsCorrect = true }, new QuizOption { OptionText = "المتغيرات", IsCorrect = false }}},
                            new QuizQuestion { QuestionText = "أي لغة برمجة هي لغة مرئية تعليمية؟", Explanation = "لغة Scratch هي لغة برمجة مرئية تعليمية.", Options = new List<QuizOption>{ new QuizOption { OptionText = "Python", IsCorrect = false }, new QuizOption { OptionText = "Scratch", IsCorrect = true }, new QuizOption { OptionText = "JavaScript", IsCorrect = false }}}
                        }
                    }
                }
            };

            secondaryStage.Grades.Add(thirdGrade);
            context.Stages.Add(secondaryStage);
            context.SaveChanges();

            // Seed Glossary if it's empty
            if (!context.GlossaryTerms.Any())
            {
                var glossaryTerms = new GlossaryTerm[]
                {
                    new GlossaryTerm { Term = "البيانات (Data)", Definition = "حقائق خام في شكل أرقام أو حروف أو رموز ليس لها معنى بحد ذاتها." },
                    new GlossaryTerm { Term = "المعلومات (Information)", Definition = "بيانات تمت معالجتها ووضعها في سياق لتصبح ذات معنى وقيمة." },
                    new GlossaryTerm { Term = "حقوق الملكية الفكرية", Definition = "حقوق قانونية تحمي الإبداعات الفكرية البشرية مثل الاختراعات والأعمال الفنية." },
                    new GlossaryTerm { Term = "أمن المعلومات", Definition = "مجموعة من الإجراءات والتقنيات التي تهدف إلى حماية سرية وسلامة وتوافر المعلومات." },
                    new GlossaryTerm { Term = "فيروس الكمبيوتر", Definition = "برنامج خبيث صغير يصيب أجهزة الكمبيوتر ويهدف إلى إتلاف البيانات أو تعطيل النظام." },
                    new GlossaryTerm { Term = "التشفير (Encryption)", Definition = "عملية تحويل البيانات إلى صيغة غير مفهومة (نص مشفر) لمنع الوصول غير المصرح به." },
                    new GlossaryTerm { Term = "وحدة المعالجة المركزية (CPU)", Definition = "تُعتبر 'عقل' الكمبيوتر، وهي مسؤولة عن تنفيذ التعليمات ومعالجة البيانات." },
                    new GlossaryTerm { Term = "الشبكة المحلية (LAN)", Definition = "شبكة كمبيوتر تربط الأجهزة ضمن منطقة جغرافية محدودة مثل منزل أو مكتب." },
                    new GlossaryTerm { Term = "عنوان IP", Definition = "عنوان رقمي فريد يُعيّن لكل جهاز متصل بشبكة كمبيوتر تستخدم بروتوكول الإنترنت للاتصال." },
                    new GlossaryTerm { Term = "نظام أسماء النطاقات (DNS)", Definition = "يعمل كـ 'دليل هاتف' للإنترنت، حيث يقوم بترجمة أسماء النطاقات التي يسهل تذكرها (مثل google.com) إلى عناوين IP." },
                    new GlossaryTerm { Term = "قاعدة البيانات (Database)", Definition = "مجموعة منظمة من البيانات المخزنة إلكترونيًا، يمكن الوصول إليها وإدارتها بسهولة." },
                    new GlossaryTerm { Term = "SQL", Definition = "لغة الاستعلام الهيكلية، وهي اللغة القياسية المستخدمة للتفاعل مع قواعد البيانات العالئقية." },
                    new GlossaryTerm { Term = "الخوارزمية (Algorithm)", Definition = "مجموعة من التعليمات أو القواعد المحددة خطوة بخطوة لحل مشكلة أو إنجاز مهمة." },
                    new GlossaryTerm { Term = "لغة البرمجة", Definition = "لغة رسمية تستخدم لكتابة التعليمات التي يمكن للكمبيوتر تنفيذها." },
                    new GlossaryTerm { Term = "المتغير (Variable)", Definition = "موقع تخزين في ذاكرة الكمبيوتر يحمل قيمة يمكن تغييرها أثناء تنفيذ البرنامج." },
                    new GlossaryTerm { Term = "الدالة (Function)", Definition = "كتلة من الكود المنظم والقابل لإعادة الاستخدام والذي يؤدي مهمة محددة." }
                };
                context.GlossaryTerms.AddRange(glossaryTerms);
                context.SaveChanges();
            }
        }
    }
}

