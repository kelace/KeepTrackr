import React, { useState, useEffect } from "react";
import {
    Calendar,
    Check,
    CheckSquare,
    Clock,
    CreditCard,
    List,
    Plus,
    Tag,
    Trash,
    Type,
    X,
    User
} from "react-feather";
import Editable from "../Editable/Editable";
import Modal from "../Modal/Modal";
import "./CardDetails.css";
import { v4 as uuidv4 } from "uuid";
import Label from "../Label/Label";
import Grid from '@mui/material/Grid';
import Button from '@mui/material/Button';
import { useSelector } from 'react-redux';
import { useDispatch } from "react-redux";
import { AppDispatch } from '../../../../app/store';
import { closeLabel, openLabel, openCalendar, addTask } from "../tasksPageSlice";
import CalendarModal from "../Calendar/Calendar";
import UserAssignWindow from "../UserAssign/UserAssignWindow";

export default function CardDetails(props: any) {
    const colors = ["#61bd4f", "#f2d600", "#ff9f1a", "#eb5a46", "#c377e0"];

    const [values, setValues] = useState({ ...props.card });
    const [input, setInput] = useState(false);

    const [text, setText] = useState(values.title);

    const labelShow = useSelector((x: any) => x.tasks.labelShow);
    const calendarShow = useSelector((x: any) => x.tasks.openedCalendar);

    const cardId = useSelector((x: any) => x.tasks.openedCardId);

    const card = useSelector((x: any) => x.tasks.cards.entities.find((c: any) => c.id == cardId));

    const labels = useSelector((x: any) => x.tasks.labels.entities.filter((c: any) => c.cardId == cardId));

    const tasks = useSelector((x: any) => x.tasks.tasks.entities.filter((c: any) => c.cardId == cardId));

    const showAssignUser = useSelector((x: any) => x.tasks.openedAssign );

    const dispatch = useDispatch<AppDispatch>();

    const Input = (props: any) => {
        return (
            <div className="">
                <input
                    autoFocus
                    defaultValue={text}
                    type={"text"}
                    onChange={(e) => {
                        setText(e.target.value);
                    }}
                />
            </div>
        );
    };

    //const addTask = (value: any) => {
    //    values.task.push({
    //        id: uuidv4(),
    //        task: value,
    //        completed: false,
    //    });
    //    setValues({ ...values });
    //};

    const removeTask = (id: any) => {
        const remaningTask = values.task.filter((item: any) => item.id !== id);
        setValues({ ...values, task: remaningTask });
    };

    const deleteAllTask = () => {
        setValues({
            ...values,
            task: [],
        });
    };

    const updateTask = (id: any) => {
        const taskIndex = values.task.findIndex((item: any) => item.id === id);
        values.task[taskIndex].completed = !values.task[taskIndex].completed;
        setValues({ ...values });
    };
    const updateTitle = (value: any) => {
        setValues({ ...values, title: value });
    };

    const defaultColor = useSelector((x: any) => x.tasks.color);

    const calculatePercent = () => {
        //const totalTask = values.task.length;
        //const completedTask = values.task.filter(
        //  (item : any) => item.completed === true
        //).length;

        //return Math.floor((completedTask * 100) / totalTask) || 0;

        return 0;
    };

    const removeTag = (id: any) => {
        const tempTag = values.tags.filter((item: any) => item.id !== id);
        setValues({
            ...values,
            tags: tempTag,
        });
    };

    const addTag = (value: any, color: any) => {
        values.tags.push({
            id: uuidv4(),
            tagName: value,
            color: color,
        });

        setValues({ ...values });
    };

    const handelClickListner = (e: any) => {
        if (e.code === "Enter") {
            setInput(false);
            updateTitle(text === "" ? values.title : text);
        } else return;
    };

    useEffect(() => {
        document.addEventListener("keypress", handelClickListner);
        return () => {
            document.removeEventListener("keypress", handelClickListner);
        };
    });

    useEffect(() => {
        if (props.updateCard) props.updateCard(props.bid, values.id, values);
    }, [values]);

    return (
        <Modal onClose={props.onClose}>
            <div className="local__bootstrap">

                <Grid container style={{ minWidth: "650px", position: "relative" }} spacing={2}>

                    <Grid item xs={12}>
                        <div className="d-flex align-items-center pt-3 gap-2">
                            <CreditCard className="icon__md" />
                            {<h5
                                style={{ cursor: "pointer" }}

                            >
                                {card.title}
                            </h5>}
                        </div>
                    </Grid>

                    <Grid item xs={8}>
                        <h6 className="text-justify">Label</h6>
                        <div
                            className="d-flex label__color flex-wrap"
                            style={{ width: "500px", paddingRight: "10px" }}
                        >
                            {
                                labels.map((item: any) => (
                                    <span
                                        className="d-flex justify-content-between align-items-center gap-2"
                                        style={{ backgroundColor: item.color }}
                                        key={item.id ?? 'newLabel'}
                                    >
                                        {item.name.length > 10
                                            ? item.name.slice(0, 6) + "..."
                                            : item.name}
                                        <X
                                            onClick={() => removeTag(item.id)}
                                            style={{ width: "15px", height: "15px" }}
                                        />
                                    </span>
                                ))

                            }
                        </div>
                        <div className="check__list mt-2">
                            <div className="d-flex align-items-end  justify-content-between">
                                <div className="d-flex align-items-center gap-2">
                                    <CheckSquare className="icon__md" />
                                    <h6>Check List</h6>
                                </div>
                                <div className="card__action__btn">
                                    <button onClick={() => deleteAllTask()}>
                                        Delete all tasks
                                    </button>
                                </div>
                            </div>
                            <div className="progress__bar mt-2 mb-2">
                                <div className="progress flex-1">
                                    <div
                                        className="progress-bar"
                                        role="progressbar"
                                        style={{ width: calculatePercent() + "%" }}
                                        aria-valuenow={75}
                                        aria-valuemin={0}
                                        aria-valuemax={100}
                                    >
                                        {calculatePercent() + "%"}
                                    </div>
                                </div>
                            </div>

                            <div className="my-2">
                                {tasks.length !== 0 ? (
                                    tasks.map((item: any, index: any) => (
                                    <div className="task__list d-flex align-items-start gap-2">
                                      <input
                                        className="task__checkbox"
                                        type="checkbox"
                                        defaultChecked={item.completed}
                                        onChange={() => {
                                          updateTask(item.id);
                                        }}
                                      />

                                      <h6
                                        className={`flex-grow-1 ${
                                          item.completed === true ? "strike-through" : ""
                                        }`}
                                      >
                                        {item.name}
                                      </h6>
                                      <Trash
                                        onClick={() => {
                                          removeTask(item.id);
                                        }}
                                        style={{
                                          cursor: "pointer",
                                          width: "18px",
                                          height: "18px",
                                        }}
                                      />
                                    </div>
                                  ))
                                ) : (
                                  <></>
                                )}

                                <Editable
                                    parentClass={"task__editable"}
                                    name={"Add Task"}
                                    btnName={"Add task"}
                                    onSubmit={(x: any) => dispatch(addTask({ taskName: x, cardId: cardId }))}
                                />
                            </div>
                        </div>
                    </Grid>

                    <Grid item xs={4}>
                        <h6>Add to card</h6>
                        <div className="d-flex card__action__btn flex-column gap-2">

                            <ul>
                                <li>
                                    <Button variant="outlined" onClick={() => dispatch(openLabel())}>

                                        <span className="icon__sm">

                                            <Tag />

                                        </span>

                                        Add Label
                                    </Button>
                                    {labelShow && (
                                        <Label
                                            color={colors}
                                            addTag={addTag}
                                            tags={values.tags}
                                            onClose={() => dispatch(closeLabel())}
                                        />
                                    )}
                                </li>
                                <li>

                                    <Button variant="outlined" onClick={() => dispatch(openCalendar())}>

                                        <span className="icon__sm">
                                            <Clock />
                                        </span>
                                        Date
                                    </Button>

                                    {calendarShow && <CalendarModal />}

                                </li>

                                <li>
                                
                                    <Button variant="outlined" onClick={() => dispatch(openCalendar())}>

                                        <span className="icon__sm">
                                            <User />
                                        </span>
                                        
                                        User
                                    </Button>


                                    {showAssignUser && <UserAssignWindow />}

                                </li>

                                <li>

                                    <Button variant="outlined" onClick={() => dispatch(openCalendar())}>

                                        <span className="icon__sm">
                                            <Trash />
                                        </span>
                                        Delete Card
                                    </Button>

                                </li>
                            </ul>

                        </div>
                    </Grid>



                </Grid>


            </div>
        </Modal>
    );
}
